using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Authors.GetStatusByJobId
{
    public class GetStatusByJobIdResponse
    {
        public Guid jobId { get; set; }
        public string status { get; set; }
        public string errorMessage {  get; set; }
    }
}
