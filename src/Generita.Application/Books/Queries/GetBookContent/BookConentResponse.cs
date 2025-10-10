using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;

namespace Generita.Application.Books.Queries.GetBookContent
{
    public class BookConentResponse
    {
        public string Title { get; set; }
        public ICollection<ParagraphDto> Paragraphs { get; set; }
    }
}
