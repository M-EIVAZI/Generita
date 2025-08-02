using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;

namespace Generita.Application.Books.Queries.SearchBook
{
    public class SearchBookHandler : IQueryHandler<SearchBookQuery, ICollection<GetBookDto>>
    {
        private IBookCategoryRepository _categoryRepository;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;

        public SearchBookHandler(IBookCategoryRepository categoryRepository, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<ErrorOr<ICollection<GetBookDto>>> Handle(SearchBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.SearchBook(request.Name);
            if (!books.Any())
            {
                return Array.Empty<GetBookDto>();
            }
            var result = await Task.WhenAll(
                books.Select(async book =>
                {
                    var author = await _authorRepository.GetById(book.AuthorId);
                    //var category = await _categoryRepository.GetById(book.CategoryId);
                    return new GetBookDto()
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = author.Name.firtName + ' ' + author.Name.LastName,
                        Cover = book.Cover,
                        access = book.Access.ToString(),
                    };
                }
                ));
            return result;

        }
    }
}
