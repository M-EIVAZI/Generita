using System.Security.Claims;

using Generita.Application.Authors.GetAllAuthorBooks;
using Generita.Application.Authors.GetStatusByJobId;
using Generita.Application.Authors.ProcessNewBook;
using Generita.Application.Common.Dtos;
using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("AllowArsemi")]

    public class AuthorController:ApiController
    {
        private IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("books")]
        [Authorize(Roles = "Author")]
        public  async Task<IActionResult> GetAllBooks()
        {
            var authorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = new GetAllAuthorBooksQuery(Guid.Parse(authorId!));
            var res = await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }
        [HttpGet("jobs/{jobId}")]
        [Authorize(Roles ="Author")]
        public async Task<IActionResult> GetStatusByJobId(Guid jobId)
        {
            var query = new GetStatusByJobIdQuery(jobId);
            var res = await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }

        [HttpPost("books/process")]
        [Authorize(Roles ="Author")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ProcessNewBook([ModelBinder(BinderType = typeof(ProcessNewBookBinder))] Application.Common.Dtos.ProcessNewBookCommand processNewBookCommand)
        {
           
                var command = processNewBookCommand.ToCommand();
                var query = new Application.Authors.ProcessNewBook.ProcessNewBookCommand(command);
            var res= await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }
    }
}
