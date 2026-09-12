using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;
using Generita.Application.Common.Messaging;
using Generita.Application.Common.Services;

using MediatR;

namespace Generita.Application.Common.Behaviors
{
    internal sealed class QueryCachingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, ErrorOr<TResponse>>
        where TRequest : ICachedQuery<TResponse>
        where TResponse : class
    {
        private readonly ICachedService _cachedService;
        public QueryCachingPipelineBehavior(ICachedService cachedService)
        {
            _cachedService = cachedService;
        }

        public Task<ErrorOr<TResponse>> Handle(
            TRequest request,
            RequestHandlerDelegate<ErrorOr<TResponse>> next,
            CancellationToken cancellationToken)
        {
            return _cachedService.GetOrCreateAsync(
                request.Key,
                token => next(token),
                request.Time,
                cancellationToken);
        }
    }
}
