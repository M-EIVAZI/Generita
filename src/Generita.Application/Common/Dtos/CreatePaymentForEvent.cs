using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos
{
    public class CreatePaymentForEvent
    {
        public Domain.Models.Transactions transactions;
        public string url { get; set; }
    }
}
