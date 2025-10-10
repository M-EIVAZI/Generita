using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

namespace Generita.Application.Common.Dtos
{
    public class HomeBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateOnly PublishedDate { get; set; }
        public string authorName { get; set; }
        public string CategoryName { get; set; }
        public string Synopsis { get; set; }
        public string Cover { get; set; }
        public string Access { get; set; }
        public string FilePath { get; set; }
    }
}
