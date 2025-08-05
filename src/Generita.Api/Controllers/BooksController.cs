using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Generita.Api.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController : ControllerBase
    {
        [HttpGet("search")]
        public Task<IActionResult> Search([FromQuery(Name = "q")] string bookName)
        {
           throw new NotImplementedException();
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
