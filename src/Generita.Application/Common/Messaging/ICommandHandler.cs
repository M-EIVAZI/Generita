using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using MediatR;

namespace Generita.Application.Common.Messaging
{
    internal interface ICommandHandler<TRequest>:IRequestHandler<TRequest,ErrorOr<Success>>
        where TRequest: IRequest<ErrorOr<Success>>
    {
    }
}
