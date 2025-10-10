using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Books.Queries.SearchBook
{
    public class SearchBookRequest
    {
        public string Name { get; set; }
        public DateOnly? PublishedDate { get; set; }
        public SearchMode SearchMode { get; set; }
        public SearchResultOrder Order { get; set; }
    }
}
