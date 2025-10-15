using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Transactions.Commands.VeriftyPayment
{
    public class VerifyPaymentHandler : IQueryHandler<VerifyPaymentQuery, string>
    {
        private ITransactionsRepository _transactionsRepository;
        private IPaymentService _paymentService;
        private IPlansRepository _plansRepository;

        public VerifyPaymentHandler(ITransactionsRepository transactionsRepository, IPaymentService paymentService, IPlansRepository plansRepository)
        {
            _transactionsRepository = transactionsRepository;
            _paymentService = paymentService;
            _plansRepository = plansRepository;
        }

        public async Task<ErrorOr<string>> Handle(VerifyPaymentQuery request, CancellationToken cancellationToken)
        {
           
            if(request.VeriftyPaymentDto.Status!="OK")
                return Error.Failure("Payment failed");
            var transaction = await _transactionsRepository.GetByAuthority(request.VeriftyPaymentDto.Authority);
            if (transaction is null)
                return Error.NotFound("authority not found");
            var plan=await _plansRepository.GetById(transaction.PlanId);
            var res=await _paymentService.VerifyPaymentAsync(request.VeriftyPaymentDto.Authority,plan.Price);
            if (res.Value.IsSuccess)
            {
                return "Payment completed";
            }
            else
                return "Payment Failed";
        }
    }
}
