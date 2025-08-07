using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Messaging;
using Generita.Application.Users.Commands.AddBookToLibrary;

namespace Generita.Application.Users.Commands.RemvoeBookFromLibrary
{
    internal class RemoveBookFromLibraryHandler : IQueryHandler<RemoveBookFromLibraryQuery, AddUserLibrarayResponse>
    {
        public Task<ErrorOr<AddUserLibrarayResponse>> Handle(RemoveBookFromLibraryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
