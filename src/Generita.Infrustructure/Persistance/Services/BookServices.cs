using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Dtos.ApiDtos;
using Generita.Application.Common.Services;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Options;
using Generita.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Generita.Domain.Common.Interfaces;
using System.Text.RegularExpressions;
using Generita.Domain.Common.Enums;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace Generita.Infrustructure.Persistance.Services
{
    internal class BookServices : IBookService
    {
        private HttpClient _httpClient;
        private IEntityRepository _entityRepository;
        private ISongRepository _songRepository;
        private IUnitOfWork _unitOfWork;
        private readonly ApplicationUrlOptions _urlOptions;
        private readonly ILogger<BookServices> _logger;

        public BookServices(
            HttpClient httpClient,
            IEntityRepository entityRepository,
            ISongRepository songRepository,
            IUnitOfWork unitOfWork,
            IOptions<ApplicationUrlOptions> urlOptions,
            ILogger<BookServices> logger)
        {
            _httpClient = httpClient;
            _entityRepository = entityRepository;
            _songRepository = songRepository;
            _unitOfWork = unitOfWork;
            _urlOptions = urlOptions.Value;
            _logger = logger;
        }

        public async Task<ErrorOr<Root>> DownloadResult(Guid jobId)
        {
            var response = await _httpClient.GetAsync($"results/{jobId}/download");
            //response.EnsureSuccessStatusCode();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var result = JsonSerializer.Deserialize<Root>(jsonContent, options);

                    if (result is null)
                    {
                        return Error.Failure(
                            code: "Job.ParseError",
                            description: "Failed to parse JSON result."
                        );
                    }

                    return result;
                }
                catch (JsonException ex)
                {
                    return Error.Failure(
                        code: "Job.JsonError",
                        description: $"Invalid JSON format: {ex.Message}"
                    );
                }
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return Error.Validation(
                    code: "Job.BadRequest",
                    description: "Job is not completed yet!"
                );
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return Error.NotFound(
                    code: "Job.NotFound",
                    description: "Job ID not found or result doesnt found"
                );
            }
            return Error.Failure(
                code: "Job.Unknown",
                description: $"Unexpected status code {response.StatusCode}"
            );
        }

        public async Task<ErrorOr<GetJobStatusResponse>> GetJobStatus(Guid jobId)
        {
            var response = await _httpClient.GetAsync($"results/{jobId}");
            //response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            _logger.LogDebug(
                "Book processor returned {StatusCode} for job {JobId}",
                (int)response.StatusCode,
                jobId);
            if (response.StatusCode == HttpStatusCode.OK)
            {
               
                var dto =  JsonSerializer.Deserialize<GetJobStatusResponse>(
            content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        );
                return dto!;
            }
            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return Error.NotFound(
                    code: "Job.NotFound",
                    description: "Job ID not found"
                    );
            }
            return Error.Failure(
                code: "Job.Unknown",
                description: $"Unexpected status code {response.StatusCode}"
            );
        }


        public async Task<ErrorOr<PostJobResponse>> PostBook(PostJobRequest request)
        {
            var abstractRegex = new Regex(@"^abstract_audio_(.+)$");
            var configDict = JsonSerializer.Deserialize<Dictionary<string, object>>(request.config_json);

            if (configDict is null)
            {
                return Error.Validation(
                    code: "Job.InvalidConfiguration",
                    description: "The book-processing configuration is not valid JSON.");
            }

            // ⚠️ نکته: فیلدهایی که خودشان دیکشنری هستند (مثل target_abstracts) 
            // به JsonElement تبدیل می‌شوند و باید به Dictionary تبدیل شوند:
            configDict["roast_model_path"] = configDict.GetValueOrDefault("llm_ollama_model") ?? string.Empty;
            if (configDict.ContainsKey("target_abstracts"))
            {
                var targetJson = (JsonElement)configDict["target_abstracts"];
                var targetDict = JsonSerializer.Deserialize<Dictionary<string, string>>(targetJson.GetRawText());
                if (targetDict is null)
                {
                    return Error.Validation(
                        code: "Job.InvalidTargetAbstracts",
                        description: "The target_abstracts configuration is not valid.");
                }
                var allKeys = targetDict.Keys.ToList(); // یا string.Join(",", targetDict.Keys)
                                                        //var song = await _songRepository.GetByEntityType(type);

                //ICollection<Songs> songs = await _songRepository.GetAll();

                //var random = new Random();

                //Guid selectedSongId;
                //if (song != null)
                //{
                //    selectedSongId = song.Id;
                //}
                //else
                //{
                //    var randomSong = songs.ElementAt(random.Next(songs.Count));
                //    selectedSongId = randomSong.Id;
                //}
                #region AddEntity&Song
                foreach (var (key, file) in request.abstract_audio)
                {
                    var match = abstractRegex.Match(key);
                    if (match.Success)
                    {
                        string abstractName = match.Groups[1].Value;
                        Entity entity = new(Guid.NewGuid())
                        {
                            type = abstractName,
                        };
                        await _entityRepository.Add(entity);
                        await _unitOfWork.CommitAsync();
                        Songs song = new(Guid.NewGuid())
                        {
                            Name = key,
                            EntityType = abstractName,
                            Owner = Domain.Enums.OwnerShip.Author,
                            AuthorId = request.AuthorId,
                        };
                        var projectRoot = Directory.GetCurrentDirectory();
                        var wwwrootPath = Path.Combine(projectRoot, "wwwroot");
                        var songFolder = Path.Combine(wwwrootPath, "Musics");
                        if (!Directory.Exists(songFolder))
                        {
                            Directory.CreateDirectory(songFolder);
                        }
                        var songName = $"{song.Id}_{Path.GetFileName(file.FileName)}";
                        song.FilePath = BuildPublicUrl($"Musics/{Uri.EscapeDataString(songName)}");
                        var songPath = Path.Combine(songFolder, songName);
                        using (var stream = new FileStream(songPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        await _songRepository.Add(song);
                        await _unitOfWork.CommitAsync();
                        entity.MusicId = song.Id;
                        await _entityRepository.Update(entity);
                        await _unitOfWork.CommitAsync();
                    }
                }
                #endregion
                configDict["target_abstracts"] = targetDict;
            }
            using var form = new MultipartFormDataContent();

            // 1️⃣ فایل اصلی (اگر موجود باشد)
            if (request.file != null)
            {
                var stream = request.file.OpenReadStream();
                var fileContent = new StreamContent(stream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(request.file.ContentType ?? "application/octet-stream");
                form.Add(fileContent, "file", request.file.FileName);
            }
            if (request.config_json != null)
            {
                // ابتدا JSON را serialize می‌کنیم
                var jsonString = JsonSerializer.Serialize(configDict);
                var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
                form.Add(jsonContent, "config_json");
            }

            // 3️⃣ ارسال درخواست
            var response = await _httpClient.PostAsync("process", form);
            var responseContent = await response.Content.ReadAsStringAsync();
            _logger.LogInformation(
                "Book processor returned {StatusCode} when starting a job",
                (int)response.StatusCode);

            // 4️⃣ پردازش پاسخ
            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                var result = JsonSerializer.Deserialize<PostJobResponse>(responseContent);
                return result!;
            }

            if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
                return Error.Custom(422, code: "Job.UnprocessableEntity", description: responseContent);

            if (response.StatusCode == HttpStatusCode.BadRequest)
                return Error.Custom(400, code: "Job.BadRequest", description: responseContent);

            return Error.Failure(code: "Job.Unknown", description: $"Unexpected status {response.StatusCode}");
        }

        private string BuildPublicUrl(string relativePath)
        {
            return $"{_urlOptions.PublicBaseUrl.TrimEnd('/')}/{relativePath.TrimStart('/')}";
        }
    }
}
