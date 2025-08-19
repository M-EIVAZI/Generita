using Generita.Application.Home.Query;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ApiController
    {
        private IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HomeResponse), StatusCodes.Status200OK)]

        public async Task<IActionResult> Home()
        {
            var query = new HomeQuery();
            var res=await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }

    }
}
