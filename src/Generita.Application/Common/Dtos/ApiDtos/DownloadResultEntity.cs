using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos.ApiDtos
{
    public class DownloadResultEntity
    {
        public string Type { get; set; }
        public string Sample { get; set; }

        // map start_pos -> StartPos
        [JsonPropertyName("start_pos")]
        public int StartPos { get; set; }
    }
}
