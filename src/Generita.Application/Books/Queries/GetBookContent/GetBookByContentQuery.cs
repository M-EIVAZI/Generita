using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

using MediatR;

namespace Generita.Application.Books.Queries.GetBookContent
{
    public record GetBookByContentQuery(Guid bookId) : ICachedQuery<BookConentResponse>
    {
        public string Key =>$"GetBookContent-{bookId}";

        public TimeSpan? Time => TimeSpan.FromMinutes(5);
    }
}
