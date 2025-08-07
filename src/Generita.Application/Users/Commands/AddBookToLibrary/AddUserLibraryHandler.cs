using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Users.Commands.AddBookToLibrary
{
    internal class AddUserLibraryHandler : IQueryHandler<AddUserLibraryQuery, AddUserLibrarayResponse>
    {
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;

        public AddUserLibraryHandler(IUserRepository userRepository, IBookRepository bookRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public Task<ErrorOr<AddUserLibrarayResponse>> Handle(AddUserLibraryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
