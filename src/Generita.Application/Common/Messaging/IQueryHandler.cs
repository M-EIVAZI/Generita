using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using MediatR;

namespace Generita.Application.Common.Messaging
{
    public interface IQueryHandler<TRequest, TResponse>
        : IRequestHandler<TRequest, ErrorOr<TResponse>>
        where TRequest : IRequest<ErrorOr<TResponse>>
    {
    }
}
