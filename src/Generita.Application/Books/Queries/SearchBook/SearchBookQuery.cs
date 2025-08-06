using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;
using Generita.Domain.Models;

namespace Generita.Application.Books.Queries.SearchBook
{
    public record SearchBookQuery(SearchBookRequest BookRequest) : IQuery<ICollection<GetBookDto>>
    {
    }
}
