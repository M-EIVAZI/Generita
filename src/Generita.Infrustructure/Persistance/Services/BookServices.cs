using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Dtos.ApiDtos;
using Generita.Application.Common.Services;
namespace Generita.Infrustructure.Persistance.Services
{
    internal class BookServices : IBookService
    {
        private HttpClient _httpClient;

        public BookServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ErrorOr<Root>> DownloadResult(Guid jobId)
        {
            var response = await _httpClient.GetAsync($"/results/{jobId}/download");
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
            var response = await _httpClient.GetAsync($"/results/{jobId}");
            //response.EnsureSuccessStatusCode();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var dto = await response.Content.ReadFromJsonAsync<GetJobStatusResponse>();
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
            var response = await _httpClient.PostAsJsonAsync($"/process", request);
            response.EnsureSuccessStatusCode();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<PostJobResponse>();

            }
            if (response.StatusCode == HttpStatusCode.BadRequest)
                return Error.Custom(402, code: "Job.BadRequest", description: "File format is not correct or is not readable");
            if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
                return Error.Custom(422, code: "Job.UnprocessableEntity", description: "File format is not correct or is not readable");
            return Error.Failure(
            code: "Job.Unknown",
            description: $"Unexpected status code {response.StatusCode}"
            );
        }
    }
}
