using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;

namespace Generita.Application.Common.Dtos
{
    public class GetJobStatusResponse
    {
        public Guid Job_id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]  
        public JobStatus Status { get; set; }
        public  string? result_path { get; set; }
        public string? error_message { get; set; }
    }
}
