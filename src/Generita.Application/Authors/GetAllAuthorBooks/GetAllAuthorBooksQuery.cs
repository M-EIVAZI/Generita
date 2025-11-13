using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Authors.GetAllAuthorBooks
{
    public record GetAllAuthorBooksQuery(Guid id) : ICachedQuery<IEnumerable<GetAllBooksResponse>>
    {
        public string Key => $"AuthorBook-{id}";

        public TimeSpan? Time => TimeSpan.FromHours(2);
    }
}
