using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Services;
using Generita.Domain.Events;

using MediatR;

namespace Generita.Application.Common.CacheInvalidation
{
    internal class CacheInvalidationBookEventHandler :
        INotificationHandler<BookAddedEvent>,
        INotificationHandler<BookRemovedEvent>
    {
        private ICachedService _cachedService;

        public CacheInvalidationBookEventHandler(ICachedService cachedService)
        {
            _cachedService = cachedService;
        }

        public async Task Handle(BookAddedEvent notification, CancellationToken cancellationToken)
        {
            await HandlerInternal(notification.AuthorId, cancellationToken,true);
            await HandlerInternal(notification.BookId, cancellationToken);
        }

        public Task Handle(BookRemovedEvent notification, CancellationToken cancellationToken)
        {
            return HandlerInternal(notification.BookId, cancellationToken);
        }
        private async Task HandlerInternal(Guid Id, CancellationToken cancellationToken)
        {
            await _cachedService.RemoveAsync("GetAllBooks");
            await _cachedService.RemoveAsync("Home");
            await _cachedService.RemoveAsync($"GetBookContent-{Id}");
            await _cachedService.RemoveAsync($"BookById-{Id}", cancellationToken);
        }
        private async Task HandlerInternal(Guid Id, CancellationToken cancellationToken,bool Author)
        {
            await _cachedService.RemoveAsync($"AuthorBook-{Id}");

        }
    }
}
