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

        public Task<IActionResult> GetBookById(int id) 
        { 
            throw new NotImplementedException();
        }
        [HttpGet("{bookId}/content")]
        public IActionResult GetBookContent(Guid bookId)
        {
            return Ok($"Content of book with ID: {bookId}");
        }


    }
}
