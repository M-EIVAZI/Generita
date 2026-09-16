using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Common.Options;
using Generita.Domain.Events;

using MediatR;
using Microsoft.Extensions.Options;

namespace Generita.Application.Transactions.Commands.VeriftyPayment
{
    public class VerifyPaymentHandler : IQueryHandler<VerifyPaymentQuery, string>
    {
        private ITransactionsRepository _transactionsRepository;
        private IPaymentService _paymentService;
        private IPlansRepository _plansRepository;
        private IPublisher _publisher;
        private readonly ApplicationUrlOptions _urlOptions;

        public VerifyPaymentHandler(ITransactionsRepository transactionsRepository, IPaymentService paymentService, IPlansRepository plansRepository, IPublisher publisher, IOptions<ApplicationUrlOptions> urlOptions)
        {
            _transactionsRepository = transactionsRepository;
            _paymentService = paymentService;
            _plansRepository = plansRepository;
            _publisher = publisher;
            _urlOptions = urlOptions.Value;
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
            if (res.IsError)
            {
                return res.Errors;
            }

            if (res.Value.IsSuccess)
            {
                VerifyPaymentEvent event1 = new()
                { Id = res.Value.Transactions.Id };
                await _publisher.Publish(event1, cancellationToken);
                return _urlOptions.ClientBaseUrl;
            }
            else
                return "Payment Failed";
        }
    }
}
