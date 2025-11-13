using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Authors.ProcessNewBook
{
    public record ProcessNewBookCommand(ProcessNewBookDto processNewBookDto) : ICommand<ProcessNewBookResponse>, ICacheInvalidationCommand
    {
        public IEnumerable<string> KeysToInvalidate => new List<string>
        {
            $"book-{processNewBookDto.Title}"
        };

    }
}
