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
    internal class CacheInvalidationPaymentEventHandler
        : INotificationHandler<CreatePaymentEvent>,
        INotificationHandler<VerifyPaymentEvent>
    {
        private ICachedService _service;

        public CacheInvalidationPaymentEventHandler(ICachedService service)
        {
            _service = service;
        }

        public Task Handle(VerifyPaymentEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(CreatePaymentEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        private async Task HandlerInternal(Guid Id, CancellationToken cancellationToken)
        {
            await _service.RemoveAsync($"Payment-{Id}", cancellationToken);
        }
    }
}
