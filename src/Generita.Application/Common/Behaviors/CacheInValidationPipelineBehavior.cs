using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;
using Generita.Application.Common.Services;

using MediatR;

namespace Generita.Application.Common.Behaviors
{
    public class CacheInValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICacheInvalidationCommand
    {
        private ICachedService _cachedService;

        public CacheInValidationPipelineBehavior(ICachedService cachedService)
        {
            _cachedService = cachedService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            // ۲. حذف کش‌ها
            foreach (var key in request.KeysToInvalidate)
            {
                await _cachedService.RemoveAsync(key, cancellationToken);
            }

            return response;
        }
    }
}
