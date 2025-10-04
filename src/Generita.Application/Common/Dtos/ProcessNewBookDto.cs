using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;

using Microsoft.AspNetCore.Http;

namespace Generita.Application.Common.Dtos
{
    public class ProcessNewBookDto
    {
        public IFormFile file { get; set; }
        public string config_json { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Cover { get; set; }
        public BookAccess Access {  get; set; }
        public DateOnly PublishedDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile Image {  get; set; }
    }
}
