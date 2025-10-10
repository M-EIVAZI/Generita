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
using Generita.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Generita.Domain.Common.Interfaces;
namespace Generita.Infrustructure.Persistance.Services
{
    internal class BookServices : IBookService
    {
        private HttpClient _httpClient;
        private IEntityRepository _entityRepository;
        private ISongRepository _songRepository;
        private IUnitOfWork _unitOfWork;

        public BookServices(HttpClient httpClient, IEntityRepository entityRepository, ISongRepository songRepository, IUnitOfWork unitOfWork)
        {
            _httpClient = httpClient;
            _entityRepository = entityRepository;
            _songRepository = songRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Root>> DownloadResult(Guid jobId)
        {
            var response = await _httpClient.GetAsync($"https://arsemi.qzz.io/results/{jobId}/download");
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
            var response = await _httpClient.GetAsync($"https://arsemi.qzz.io/results/{jobId}");
            //response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);
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
            var url = "https://arsemi.qzz.io/process";
            var configDict = JsonSerializer.Deserialize<Dictionary<string, object>>(request.config_json);

            // ⚠️ نکته: فیلدهایی که خودشان دیکشنری هستند (مثل target_abstracts) 
            // به JsonElement تبدیل می‌شوند و باید به Dictionary تبدیل شوند:
            configDict.Add("roast_model_path", configDict.GetValueOrDefault("llm_ollama_model"));
            if (configDict != null && configDict.ContainsKey("target_abstracts"))
            {
                var targetJson = (JsonElement)configDict["target_abstracts"];
                var targetDict = JsonSerializer.Deserialize<Dictionary<string, string>>(targetJson.GetRawText());
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
                foreach (var key in allKeys)
                {
                    Entity entity = new(Guid.NewGuid())
                    {
                        type = key
                    };
                    await _entityRepository.Add(entity);
                    // ذخیره یا اضافه کردن به DbContext
                }
                await _unitOfWork.CommitAsync();
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
            var response = await _httpClient.PostAsync(url, form);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response content: {responseContent}");

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
    }
}
