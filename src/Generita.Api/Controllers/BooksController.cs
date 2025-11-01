using Generita.Application.Books.Commands.RemoveBook;
using Generita.Application.Books.Queries.GetAllBookCategories;
using Generita.Application.Books.Queries.GetBookById;
using Generita.Application.Books.Queries.GetBookContent;
using Generita.Application.Books.Queries.SearchBook;
using Generita.Application.Common.Dtos;
using Generita.Application.Dtos;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [ApiController]
    [Route("books")]
    [EnableCors("AllowArsemi")]

    public class BooksController : ApiController
    {
        private IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search")]
        [Authorize(Roles = "Reader")]
        [ProducesResponseType(typeof(GetBookDto), StatusCodes.Status200OK)]
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
        [Authorize(Roles = "Reader")]
        [ProducesResponseType(typeof(GetBookDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookById(Guid id) 
        {
            var query = new GetBookByIdQuery(id);
            var result=await _mediator.Send(query);
            return result.Match(Ok,Problem);
        }
        [HttpGet("{bookId}/content")]
        [ProducesResponseType(typeof(BookConentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetBookContent(Guid bookId)
        {
            var query = new GetBookByContentQuery(bookId);
            var result=await _mediator.Send(query);
            return result.Match(Ok,Problem);
        }
        [HttpGet("Categories/GetAll")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize]
        [ProducesResponseType(typeof(ICollection<GetAllBookCategoriesResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllBookCategoriesQuery();
            var res=await _mediator.Send(query);
            return res.Match(Ok,Problem);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="Author")]
        public async Task<IActionResult> RemoveBook(Guid id)
        {
            var command = new RemoveBookCommand(id);
            var res = await _mediator.Send(command);
            return res.Match(_ => Ok(), Problem);
        }
    }
}
