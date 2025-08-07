using System.Security.Claims;

using Generita.Application.Common.Dtos;
using Generita.Application.Users.Commands.AddBookToLibrary;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Library")]
        [Authorize]
        public async Task<IActionResult> AddToLibrary([FromBody]AddTolibraryControllerDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AddUserLibraryRequest request = new()
            {
                BookId = dto.bookId,
                UserId=Guid.Parse(userId!),
            };
            var query=new AddUserLibraryQuery(request);
            var result=await _mediator.Send(query); 
            return result.Match(Ok,Problem);

        }
        [HttpDelete("Library/{bookId}")]
        public async Task<IActionResult> Library([FromRoute] Guid bookId)
        {
            throw new NotImplementedException();
        }



    }
}
