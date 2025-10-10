using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Generita.Application.Dtos;

namespace Generita.Application.Books.Commands.AddBook
{
    public record AddBookCommand(AddBookDto AddBookDto):Application.Common.Messaging.ICommand
    {
    }
}
