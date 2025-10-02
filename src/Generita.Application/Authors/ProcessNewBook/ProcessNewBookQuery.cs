using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Authors.ProcessNewBook
{
    public record ProcessNewBookQuery(ProcessNewBookDto processNewBookDto) : IQuery<ProcessNewBookResponse>
    {
    }
}
