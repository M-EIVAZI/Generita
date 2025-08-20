using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;

namespace Generita.Application.Books.Queries.GetBookById
{
    public record GetBookByIdQuery(Guid Id):IQuery<GetBookDto>
    {
    }
}
