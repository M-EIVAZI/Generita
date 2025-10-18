using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;

using Microsoft.AspNetCore.Http;

namespace Generita.Application.Common.Dtos
{
    public class PostJobRequest
    {
        //public string? Title { get; set; }
        //public string classifier_driver { get; set; } = "nn";
        //public string? extractor_driver { get; set; } = "llm";
        //public float? confidence_threshold { get; set; } = 0.85f;
        //public IEnumerable<MusicSense>? allowed_senses { get; set; }
        //public IEnumerable<AgeClasses>? allowed_ages { get; set; }
        //public string? nn_checkpoint_path { get; set; } = "checkpoints/best-model.ckpt";
        //public string? llm_ollama_model { get; set; } = "phi4-mini";
        //public string? roast_model_path { get; set; } = "QA_RoBERTA_SQUADv2";
        //public IEnumerable<Dictionary<string, string>>? target_abstracts { get; set; }
        public Dictionary<string, IFormFile> abstract_audio { get; set; }
        public Guid AuthorId { get; set; }
        public string config_json { get; set; }
        public IFormFile file { get; set; }

    }
}
