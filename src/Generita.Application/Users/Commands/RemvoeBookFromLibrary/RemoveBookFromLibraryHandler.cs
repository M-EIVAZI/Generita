using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Users.Commands.AddBookToLibrary;
using Generita.Domain.Common.Interfaces;

namespace Generita.Application.Users.Commands.RemvoeBookFromLibrary
{
    internal class RemoveBookFromLibraryHandler : IQueryHandler<RemoveBookFromLibraryQuery, AddUserLibrarayResponse>
    {
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;

        public RemoveBookFromLibraryHandler(IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async  Task<ErrorOr<AddUserLibrarayResponse>> Handle(RemoveBookFromLibraryQuery request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById(request.addUserLibraryRequest.UserId) is null)
                return Error.NotFound();
            if (await _bookRepository.GetById(request.addUserLibraryRequest.BookId) is null)
                return Error.NotFound();
            await _userRepository.DeleteBookFromLibrary(request.addUserLibraryRequest.BookId, request.addUserLibraryRequest.UserId);
            await _unitOfWork.CommitAsync();
            var userbooks = await _userRepository.GetByIdWithBooks(request.addUserLibraryRequest.UserId);
            AddUserLibrarayResponse  res = new() { LibraryBookIds = userbooks.Select(x => x.BookId).ToList() };
            return res;
        }
    }
}

