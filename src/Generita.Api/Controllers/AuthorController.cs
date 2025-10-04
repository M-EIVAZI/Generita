using Generita.Application.Authors.GetAllAuthorBooks;
using Generita.Application.Authors.GetStatusByJobId;
using Generita.Application.Authors.ProcessNewBook;
using Generita.Application.Common.Dtos;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorController:ApiController
    {
        private IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("books")]
        [Authorize]
        public  async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllAuthorBooksQuery();
            var res = await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }
        [HttpGet("jobs/{jobId}")]
        [Authorize]
        public async Task<IActionResult> GetStatusByJobId(Guid id)
        {
            var query = new GetStatusByJobIdQuery(id);
            var res = await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }

        [HttpPost("books/process")]
        [Authorize]
        public async Task<IActionResult> ProcessNewBook(ProcessNewBookDto processNewBookDto)
        {
            var query = new ProcessNewBookQuery(processNewBookDto);
            var res= await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }
    }
}
