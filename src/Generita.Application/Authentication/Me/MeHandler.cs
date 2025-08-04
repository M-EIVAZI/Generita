using System;
using System.Collections.Generic;
using System.Linq;
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

        public MeHandler(IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork, ITransactionsRepository transactionsRepository)
        {
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _transactionsRepository = transactionsRepository;
        }
        public async Task<ErrorOr<MeResponse>> Handle(MeCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdWithBooks(request.Id);

            if (user == null)
            {
                return Error.NotFound(description: "user with these information doesn't found");
            }
            var trans = await _transactionsRepository.GetByUserId(request.Id);
            string Subscriptionstatus;
            if (trans is not null)
            {

                if (trans.CreateAt.AddDays(trans.Plan.Duration) > DateTime.UtcNow)
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
                    LibraryBookIds = user.Books.Select(x => x.Id).ToList(),
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
                    LibraryBookIds = user.Books.Select(x => x.Id).ToList(),
                };
            return res;
            }
        }


    }
}
