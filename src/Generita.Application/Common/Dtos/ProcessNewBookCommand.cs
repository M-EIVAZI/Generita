using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Generita.Application.Common.Dtos
{
    public class ProcessNewBookCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Synopsis { get; set; } = string.Empty;
        public string Access { get; set; } = string.Empty; // raw
        public string PublishedDate { get; set; } = string.Empty; // raw
        public string CategoryId { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public string ConfigJson { get; set; } = string.Empty;

        public IFormFile? Image { get; set; }
        public IFormFile? File { get; set; }

        public Dictionary<string, IFormFile> AbstractAudios { get; set; } = new();
        public Dictionary<string, IFormFile> SituationalAudios { get; set; } = new();
    }
}
