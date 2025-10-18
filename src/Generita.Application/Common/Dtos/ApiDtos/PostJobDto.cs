using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Generita.Application.Common.Dtos.ApiDtos
{
    public class PostJobDto
    {
        public string config_json { get; set; }
        public IFormFile file { get; set; }
    }
}
