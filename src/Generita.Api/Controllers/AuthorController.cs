using Generita.Application.Authors.GetAllAuthorBooks;
using Generita.Application.Authors.GetStatusByJobId;

using MediatR;

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
        public  async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllAuthorBooksQuery();
            var res = await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }
        [HttpGet("jobs/{jobId}")]
        public async Task<IActionResult> GetStatusByJobId(Guid id)
        {
            var query = new GetStatusByJobIdQuery(id);
            var res = await _mediator.Send(query);
            return res.Match(Ok, Problem);
        }
    }
}
