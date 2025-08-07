using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Users.Commands.AddBookToLibrary
{
    public record AddUserLibraryQuery(AddUserLibraryRequest GetUserLibraryRequest) : IQuery<AddUserLibrarayResponse>
    {
    }
}
