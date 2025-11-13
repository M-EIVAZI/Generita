using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Generita.Domain.Events
{
    public class CreatePaymentEvent:INotification
    {
        public Guid PaymentId { get; set; }
    }
}
