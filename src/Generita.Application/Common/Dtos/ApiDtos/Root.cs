using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Dtos.ApiDtos
{
    public class Root
    {
        public string Title { get; set; }

        public List<DownloadResultParagraph> Paragraphs { get; set; }

        // map canonical_entity_bank -> Dictionary<string, List<string>>
        [JsonPropertyName("canonical_entity_bank")]
        public Dictionary<string, List<string>> CanonicalEntityBank { get; set; }

        // map job_id
        [JsonPropertyName("job_id")]
        public Guid JobId { get; set; }
    }
}
