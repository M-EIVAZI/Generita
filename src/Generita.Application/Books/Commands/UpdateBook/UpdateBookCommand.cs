using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Books.Commands.UpdateBook
{
    public record UpdateBookCommand(Book books):Application.Common.Messaging.ICommand
    {
    }
}
