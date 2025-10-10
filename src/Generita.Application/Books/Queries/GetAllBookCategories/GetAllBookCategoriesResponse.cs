using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Books.Queries.GetAllBookCategories
{
    public class GetAllBookCategoriesResponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }    
    }
}
