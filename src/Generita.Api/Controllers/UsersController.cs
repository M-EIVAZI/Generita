using System.Security.Claims;

using Generita.Application.Common.Dtos;
using Generita.Application.Dtos;
using Generita.Application.Users.Commands.AddBookToLibrary;
using Generita.Application.Users.Commands.RemvoeBookFromLibrary;
using Generita.Domain.Models;

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
        [ProducesResponseType(typeof(AddUserLibrarayResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


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
        [ProducesResponseType(typeof(RegisterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Library([FromRoute] Guid bookId)
        {
             var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            AddUserLibraryRequest request = new()
            {
                BookId = bookId,
                UserId = Guid.Parse(userId!),
            };
            var query=new RemoveBookFromLibraryQuery(request);
            var result=await _mediator.Send(query);
            return result.Match(Ok,Problem);

        }



    }
}
