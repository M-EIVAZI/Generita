using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;
using Generita.Application.Users.Commands.AddBookToLibrary;

namespace Generita.Application.Users.Commands.RemvoeBookFromLibrary
{
    public record RemoveBookFromLibraryQuery(AddUserLibraryRequest addUserLibraryRequest):IQuery<AddUserLibrarayResponse>
    {
    }
}
