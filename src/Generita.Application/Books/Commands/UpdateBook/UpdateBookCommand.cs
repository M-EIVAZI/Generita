using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;
using Generita.Application.Common.Caching;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Commands.UpdateBook
{
    public record UpdateBookCommand(Book books) : ICommand, ICacheInvalidationCommand
    {
        public IEnumerable<string> KeysToInvalidate =>
        [
            CacheKeys.Home,
            CacheKeys.AuthorBooks(books.AuthorId),
            CacheKeys.BookById(books.Id),
            CacheKeys.BookContent(books.Id)
        ];
    }
}
