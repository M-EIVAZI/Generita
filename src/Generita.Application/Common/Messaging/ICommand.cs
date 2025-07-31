using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using MediatR;

namespace Generita.Application.Common.Messaging
{
    interface ICommand:IRequest<ErrorOr<Success>>
    {
    }
}
