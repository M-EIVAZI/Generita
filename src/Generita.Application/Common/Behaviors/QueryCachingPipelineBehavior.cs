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
    internal class QueryCachingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICachedQuery<TResponse>
        where TResponse:class
    {
        private ICachedService _cachedService;
        public QueryCachingPipelineBehavior(ICachedService cachedService)
        {
            _cachedService = cachedService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            return await _cachedService.GetOrCreateAsync<TResponse>
                (request.Key,
                _ =>  next(),
                request.Time,
                cancellationToken
                );
        }
    }
}
