using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;

namespace Generita.Application.Common.Dtos
{
    public class PostJobResponse
    {
        public Guid job_id { get; set; }
        public JobStatus Status { get; set; }
        public string message {  get; set; }
    }
}
