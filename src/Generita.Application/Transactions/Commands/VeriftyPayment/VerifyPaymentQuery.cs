using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Transactions.Commands.VeriftyPayment
{
    public record VerifyPaymentQuery(VeriftyPaymentDto VeriftyPaymentDto):IQuery<string>
    {
    }
}
