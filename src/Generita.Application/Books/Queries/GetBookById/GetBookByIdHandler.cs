using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;

using Microsoft.IdentityModel.Tokens;

namespace Generita.Application.Books.Queries.GetBookById
{
    internal class GetBookByIdHandler : IQueryHandler<GetBookByIdQuery, GetBookDto>
    {
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private IBookCategoryRepository _bookCategoryRepository;

        public GetBookByIdHandler(IBookRepository bookRepository, IAuthorRepository authorRepository, IBookCategoryRepository bookCategoryRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<ErrorOr<GetBookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book =await _bookRepository.GetById(request.Id);
            if (book is null)
            {
                return Error.NotFound("404NotFound", "Book with these id isnt found");
            }
            var author=await _authorRepository.GetById(book.AuthorId);
            var bookcategory=await _bookCategoryRepository.GetById(book.CategoryId);
            var res = new GetBookDto()
            {
                id = book.Id,
                title = book.Title,
                authorName = author.Name,
                synopsis = book.Synopsis,
                categoryName = bookcategory.CategoryName,
                cover=book.Cover,
                access=book.Access.ToString(),
            };
            return res;
        }
    }
}
