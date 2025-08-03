using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;

namespace Generita.Application.Authentication.Login
{
    public record LoginCommand(LoginDto LoginDto) :ICommand<LoginResponse>
    {
    }
}
