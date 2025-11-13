using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Dtos.ApiDtos
{
    public class PaymentVerifyResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public Domain.Models.Transactions Transactions { get; set; }
    }

}
