using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Queries.GetAllBookCategories
{
    public class GetAllBookCategoriesQuery : ICachedQuery<ICollection<GetAllBookCategoriesResponse>>
    {
        public string Key => "GetAllBooks";

        public TimeSpan? Time => TimeSpan.FromMinutes(15);
    }
}
