using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using ErrorOr;

using Generita.Application.Common.Dtos.ApiDtos;
using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

using MediatR;

using Microsoft.Extensions.Options;

namespace Generita.Infrustructure.Persistance.Services
{
    internal class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _merchantId;
        private readonly string _callbackUrl;
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(HttpClient httpClient, IOptions<ZarinPalOptions> zarinPalOptions, ITransactionsRepository transactionsRepository, IUnitOfWork unitOfWork)
        {
            _httpClient = httpClient;
            _merchantId = zarinPalOptions.Value.MerchantId ;
            _callbackUrl = zarinPalOptions.Value.CallbackUrl;
            _transactionsRepository = transactionsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<string>> CreatePaymentAsync(Guid userid, Guid planid, int amount, string description)
        {
            var payment = new Transactions(Guid.NewGuid())
            {
                PlanId=planid,
                CreateAt=DateTime.UtcNow,
                Price=amount,
                States=Domain.Enums.States.Pending,
                UserId=userid,
            };
            var request = new CreatePaymentRequest()
            {
                amount=amount,
                callback_url=_callbackUrl,
                description=description,
                merchant_id=_merchantId,
            };
            var response= await _httpClient.PostAsJsonAsync("https://sandbox.zarinpal.com/pg/v4/payment/request.json", request);
            var raw = await response.Content.ReadAsStringAsync();
            Console.WriteLine(raw);
            var result = await response.Content.ReadFromJsonAsync<CreatePaymentResponse>();

            if(result?.data.code==100)
            {
                payment.Authority=result.data.authority;
                await _transactionsRepository.Add(payment);
                await _unitOfWork.CommitAsync();
                return $"https://sandbox.zarinpal.com/pg/StartPay/{payment.Authority}";

            }
            else
                payment.States=Domain.Enums.States.Failed;
                await _transactionsRepository.Add(payment);
                await _unitOfWork.CommitAsync();
            return "";

        }

        public async  Task<ErrorOr<PaymentVerifyResult>> VerifyPaymentAsync(string authority,int amount)
        {
            var request = new VerifyPaymentRequest()
            {
                merchant_id = _merchantId,
                authority = authority,
                amount = amount
            };
            var response = await _httpClient.PostAsJsonAsync("https://sandbox.zarinpal.com/pg/v4/payment/verify.json", request);
            var result = await response.Content.ReadFromJsonAsync<VerifyPaymentResonse>();
            var payment = await _transactionsRepository.GetByAuthority(authority);
            if (payment is null)
                return Error.Failure();
            if (result?.data?.code == 100 || result?.data?.code == 101)
            {
                payment.RefId = result.data.ref_id;
                payment.car_pan = result.data.card_pan;
                payment.States = Domain.Enums.States.Success;
                payment.PaidAt = DateTime.UtcNow;
                await _transactionsRepository.Update(payment);
                await _unitOfWork.CommitAsync();

                return new PaymentVerifyResult
                {
                    IsSuccess = true,

                    Message = result.data.message,
                };
            }
            payment.States = Domain.Enums.States.Failed;
            await _unitOfWork.CommitAsync();

            return new PaymentVerifyResult
            {
                IsSuccess = false,
                Message = result?.data?.message ?? "پرداخت ناموفق بود"
            };
        }
    }
}
