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
    public sealed class CacheInvalidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICacheInvalidationCommand
    {
        private readonly ICachedService _cachedService;

        public CacheInvalidationPipelineBehavior(ICachedService cachedService)
        {
            _cachedService = cachedService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next(cancellationToken);

            var removals = request.KeysToInvalidate
                .Where(key => !string.IsNullOrWhiteSpace(key))
                .Distinct(StringComparer.Ordinal)
                .Select(key => _cachedService.RemoveAsync(key, cancellationToken));

            await Task.WhenAll(removals);

            return response;
        }
    }
}
