using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Authentication.Refresh;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Interfaces;

using MediatR;

namespace Generita.Application.Authentication.Me
{
    public class MeHandler : ICommandHandler<MeCommand, MeResponse>
    {
        private IUserRepository _userRepository;
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;
        private ITransactionsRepository _transactionsRepository;
        private IAuthorRepository _authorRepository;

        public MeHandler(IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork, ITransactionsRepository transactionsRepository, IAuthorRepository authorRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _transactionsRepository = transactionsRepository;
            _authorRepository = authorRepository;
        }

        public async Task<ErrorOr<MeResponse>> Handle(MeCommand request, CancellationToken cancellationToken)
        {
            var userbook = await _userRepository.GetByIdWithBooks(request.Id);
            var user = await _userRepository.GetById(request.Id);
            var author = await _authorRepository.GetById(request.Id);
            if (user == null && author==null)
            {
                return Error.NotFound(description: "user with these information doesn't found");
            }
            var trans = await _transactionsRepository.GetByUserId(request.Id);
            string Subscriptionstatus;
            if(user != null)
            {
                if (trans is not null)
                {

                    if (trans.CreateAt.AddDays(trans.Plan.Duration) < DateTime.UtcNow)
                        Subscriptionstatus = "InActive";
                    else
                        Subscriptionstatus = "Active";
                    MeResponseSubscription MeResponseSubscription = new() { status = Subscriptionstatus, ExpiryDate = DateOnly.FromDateTime(trans.CreateAt.AddDays(trans.Plan.Duration)) };
                    MeResponse res = new()
                    {
                        Id = request.Id,
                        Email = user.Email,
                        Name = user.Name,
                        Subscription = MeResponseSubscription,
                        Role="reader",
                        LibraryBookIds = userbook.Select(x => x.BookId).ToList(),
                    };
                    return res;
                }
                else
                {
                    MeResponse res = new()
                    {
                        Id = request.Id,
                        Email = user.Email,
                        Name = user.Name,
                        Subscription = null,
                        Role="reader",
                        LibraryBookIds = userbook.Select(x => x.BookId).ToList(),
                    };
                    return res;
                }
            }
           else if(author !=null)
            {
                var books =await  _authorRepository.GetAuthorBooks(author.Id);
                MeResponseSubscription sub = new();
                MeResponse res = new()
                {
                    Id = author.Id,
                    Name=author.Name,
                    Email = author.Email,
                    Subscription = null,
                    Role="author",
                    LibraryBookIds = books.Books.Select(x => x.Id).ToList()
                };
                return res;
            }
            return Error.NotFound();
        }
        

    }
}
