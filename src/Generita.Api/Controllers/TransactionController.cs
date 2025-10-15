using System.Runtime.CompilerServices;
using System.Security.Claims;

using Generita.Application.Transactions.Commands.CreatePayment;
using Generita.Application.Transactions.Commands.VeriftyPayment;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TransactionController : ApiController
    {
        private IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Reader")]
        [HttpPost]
        public async Task<IActionResult> CreatePayment(Guid planId)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            CreatePaymentDto createPaymentDto = new()
            {
                planId = planId,
                userId = Guid.Parse(userid!),
            };
            var command = new CreatePaymentQuery(createPaymentDto);
            var res = await _mediator.Send(command);
            return res.Match(Ok, Problem);
        }
        [HttpGet]
        public async Task<IActionResult> VerifyPayment([FromQuery] string Authority, [FromQuery] string Status)
        {
            var command =new VerifyPaymentQuery(new VeriftyPaymentDto() {Authority = Authority, Status = Status});
            var res = await _mediator.Send(command);
            return res.Match(Ok, Problem);
        }
    }
}
