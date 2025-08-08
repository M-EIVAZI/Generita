using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Enums;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

namespace Generita.Application.Users.Commands.AddBookToLibrary
{
    internal class AddUserLibraryHandler : IQueryHandler<AddUserLibraryQuery, AddUserLibrarayResponse>
    {
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork
        private ITransactionsRepository _transactionsRepository;

        public AddUserLibraryHandler(IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork, ITransactionsRepository transactionsRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _transactionsRepository = transactionsRepository;
        }

        public async  Task<ErrorOr<AddUserLibrarayResponse>> Handle(AddUserLibraryQuery request, CancellationToken cancellationToken)
        {
            bool HasSubscription=true;
            //check if user hasnt got subscipriton and the book isnt free return error
            var book = await _bookRepository.GetById(request.GetUserLibraryRequest.BookId);
            if (book is null)
                return Error.NotFound(description: "Book doesn't found");
            var transaction = await _transactionsRepository.GetByUserId(request.GetUserLibraryRequest.UserId);
            if (transaction is null)
                HasSubscription = false;
            else HasSubscription = transaction.CreateAt.AddDays(transaction.Plan.Duration) >= DateTime.UtcNow;
            if (book.Access == BookAccess.Free)
            {

                UserBook userbook = new(Guid.NewGuid())
                {
                    BookId = request.GetUserLibraryRequest.BookId,
                    UserId = request.GetUserLibraryRequest.UserId,
                };
                await _userRepository.AddBookToLibrary(userbook);
                await _unitOfWork.CommitAsync(cancellationToken);
                var newbooks = await _userRepository.GetByIdWithBooks(request.GetUserLibraryRequest.UserId);
                AddUserLibrarayResponse res = new()
                { LibraryBookIds = newbooks.Select(x => x.BookId).ToList() };
                return res;

            }
            else if (book.Access == BookAccess.Subscription && HasSubscription == false)
                return Error.Forbidden(description: "User doesn't have active subscription");
            else
            {
                UserBook userbook = new(Guid.NewGuid())
                {
                    BookId = request.GetUserLibraryRequest.BookId,
                    UserId = request.GetUserLibraryRequest.UserId,
                };
                await _userRepository.AddBookToLibrary(userbook);
                await _unitOfWork.CommitAsync();
                var newbooks =await  _userRepository.GetByIdWithBooks(request.GetUserLibraryRequest.UserId);
                AddUserLibrarayResponse res = new()
                { LibraryBookIds = newbooks.Select(x => x.BookId).ToList() };
                return res;
            }
        }
    }
}
