using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Caching;
using Generita.Application.Common.Services;
using Generita.Domain.Events;

using MediatR;

namespace Generita.Application.Common.CacheInvalidation
{
    internal class CacheInvalidationBookEventHandler :
        INotificationHandler<BookAddedEvent>,
        INotificationHandler<BookRemovedEvent>
    {
        private readonly ICachedService _cachedService;

        public CacheInvalidationBookEventHandler(ICachedService cachedService)
        {
            _cachedService = cachedService;
        }

        public async Task Handle(BookAddedEvent notification, CancellationToken cancellationToken)
        {
            await InvalidateBookAsync(notification.BookId, notification.AuthorId, cancellationToken);
        }

        public async Task Handle(BookRemovedEvent notification, CancellationToken cancellationToken)
        {
            await InvalidateBookAsync(notification.BookId, notification.AuthorId, cancellationToken);
        }

        private Task InvalidateBookAsync(Guid bookId, Guid authorId, CancellationToken cancellationToken)
        {
            return Task.WhenAll(
                _cachedService.RemoveAsync(CacheKeys.Home, cancellationToken),
                _cachedService.RemoveAsync(CacheKeys.AuthorBooks(authorId), cancellationToken),
                _cachedService.RemoveAsync(CacheKeys.BookContent(bookId), cancellationToken),
                _cachedService.RemoveAsync(CacheKeys.BookById(bookId), cancellationToken));
        }
    }
}
