using Generita.Application.Plan.Queries.GetAllPlans;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PlansController : ApiController
    {
        private IMediator _mediator;

        public PlansController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<PlanDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPlans()
        {
            var query=new GetAllPlansQuery();
            var res=await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }
    }
}
