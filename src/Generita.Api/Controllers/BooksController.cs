using Generita.Application.Books.Queries.GetBookById;
using Generita.Application.Books.Queries.GetBookContent;
using Generita.Application.Books.Queries.SearchBook;
using Generita.Application.Common.Dtos;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ApiController
    {
        private IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> Search([FromQuery(Name = "q")] string Name,SearchBookDto searchBook)
        {

            SearchBookRequest searchBookRequest = new()
            {
                Name = Name,
                Order = searchBook.Order,
                SearchMode = searchBook.SearchMode,
                PublishedDate = searchBook.PublishedDate,
            };
            var query = new SearchBookQuery(searchBookRequest);
            var result = await _mediator.Send(query);
            return result.Match(Ok,Problem);
        }
        [HttpGet("{id}")]
        [Authorize]

        public async Task<IActionResult> GetBookById(Guid id) 
        {
            var query = new GetBookByIdQuery(id);
            var result=await _mediator.Send(query);
            return result.Match(Ok,Problem);
        }
        [HttpGet("{bookId}/content")]
        public async Task<IActionResult> GetBookContent(Guid bookId)
        {
            var query = new GetBookByContentQuery(bookId);
            var result=await _mediator.Send(query);
            return result.Match(Ok,Problem);
        }


    }
}
