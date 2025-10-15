using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos.ApiDtos;

namespace Generita.Application.Common.Interfaces
{
    public interface IPaymentService
    {
        public Task<ErrorOr<string>> CreatePaymentAsync(Guid userid,Guid planid,int amount,string description);
        public Task<ErrorOr<PaymentVerifyResult>> VerifyPaymentAsync(string authority, int amount );
    }
}
