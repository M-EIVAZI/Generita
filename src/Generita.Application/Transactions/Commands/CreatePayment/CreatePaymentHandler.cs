using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Transactions.Commands.CreatePayment
{
    public class CreatePaymentHandler : IQueryHandler<CreatePaymentQuery, string>
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserRepository _userRepository;
        private readonly IPlansRepository _planRepository;
        private readonly ITransactionsRepository _transactionsRepository;

        public CreatePaymentHandler(IPaymentService paymentService, IUserRepository userRepository, IPlansRepository planRepository, ITransactionsRepository transactionsRepository)
        {
            _paymentService = paymentService;
            _userRepository = userRepository;
            _planRepository = planRepository;
            _transactionsRepository = transactionsRepository;
        }

        public async Task<ErrorOr<string>> Handle(CreatePaymentQuery request, CancellationToken cancellationToken)
        {
            var user =await  _userRepository.GetById(request.CreatePaymentDto.userId);
            var plan =await _planRepository.GetById(request.CreatePaymentDto.planId);
            if (user is null)
                return Error.NotFound($"User with this id not found");
            if(plan is null) 
                return Error.NotFound("there is no plan with this id");
            var transaction = await _transactionsRepository.GetByPlanIdUserId(plan.Id, user.Id);
            if (transaction is not null)
            {
                var tplan=await _planRepository.GetById(transaction.PlanId);
                if(transaction.CreateAt.AddDays(tplan.Duration) > DateTime.Now)
                    return Error.Conflict(description:"The user have already an active plan");
            }
            var res = await _paymentService.CreatePaymentAsync(user.Id, plan.Id, plan.Price, plan.Description);
            if(res.Value is null  )
                return Error.Conflict("there is a problem with payment");
            return res;
        }
    }

}
