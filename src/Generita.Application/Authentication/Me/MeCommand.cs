using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Authentication.Me
{
    public record MeCommand(Guid Id):ICommand<MeResponse>
    {
    }
}
