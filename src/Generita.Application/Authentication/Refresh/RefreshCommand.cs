using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Authentication.Refresh
{
    public record RefreshCommand(RefreshRequest refreshRequest):ICommand<RefreshResponse>
    {
    }
}
