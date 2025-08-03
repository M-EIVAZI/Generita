using ErrorOr;

using Generita.Application.Authentication.Register;
using Generita.Application.Dtos;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            var command=new RegisterCommand(registerDto);
            var result=await _mediator.Send(command);
            return result.Match(Ok, Problem);
        }
        [HttpPost]
        public Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public Task<IActionResult> Refresh(RefreshDto refreshDto)
        {
            throw new NotImplementedException();
        }
        [HttpGet]
        public Task<IActionResult> Me()
        {
            throw new NotImplementedException();
        }
        
    }
}
