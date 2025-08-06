using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Books.Queries.SearchBook;

namespace Generita.Application.Common.Dtos
{
    public class SearchBookDto
    {
        public SearchMode SearchMode { get; set; }
        public SearchResultOrder Order { get; set; }
        public DateOnly PublishedDate { get; set; }
    }
}
