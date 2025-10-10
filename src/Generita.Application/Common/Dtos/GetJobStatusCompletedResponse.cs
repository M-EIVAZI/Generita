using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;

namespace Generita.Application.Common.Dtos
{
    public class GetJobStatusCompletedResponse:GetJobStatusQueuedResponse
    {

        public string result_path { get; set; }
    }
}
