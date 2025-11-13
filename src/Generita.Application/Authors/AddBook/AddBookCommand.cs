using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;

using ICommand = Generita.Application.Common.Messaging.ICommand;

namespace Generita.Application.Authors.AddBook
{
    public record AddBookCommand(AuthorAddBookDto Dto) : ICommand
    {


    }
}
