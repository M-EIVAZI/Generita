using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Commands.RemoveBook
{
    public record RemoveBookCommand(Guid Id) : ICommand
    {
    }
}
