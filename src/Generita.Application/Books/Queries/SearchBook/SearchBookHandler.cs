using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Dtos;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore.Metadata;

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
            if (request.BookRequest.SearchMode == SearchMode.ByTitle)
            {
                var books = await _bookRepository.SearchBook(request.BookRequest.Name);
                if (!books.Any())
                {
                    return Array.Empty<GetBookDto>();
                }
                var likes=await _bookRepository.GetLikesNumber(books.Select(x=>x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    _ => books
                };
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
            else if (request.BookRequest.SearchMode == SearchMode.ByCategory)
            {
                var catbooks = await _categoryRepository.GetByName(request.BookRequest.Name);
                var books = catbooks.SelectMany(x=>x.Books).ToList();
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    _ => books
                };
                var result = await Task.WhenAll(
                    books.Select(async book =>
                    {
                        var author = await _authorRepository.GetById(book.AuthorId);
                        return new GetBookDto()
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Author = author.Name.firtName + ' ' + author.Name.LastName,
                            Cover = book.Cover,
                            access = book.Access.ToString()
                        };

                    }));
                return result;
            }
            else if(request.BookRequest.SearchMode==SearchMode.ByAuthorName)
            {
                var authors = await _authorRepository.GetByAuthorName(request.BookRequest.Name);
                var books = authors.Books;
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    _ => books
                };
                var result = await Task.WhenAll((
                    books.Select(async book =>
                    {
                        return new GetBookDto()
                        {
                            Author = authors.Name.firtName + ' ' + authors.Name.LastName,
                            Title = book.Title,
                            Cover = book.Cover,
                            access = book.Access.ToString(),
                        };

                    })));
                return result;
            }
            else if (request.BookRequest.SearchMode == SearchMode.ByPublishedDate)
            {
                var books = await _bookRepository.GetByPublishedDate(request.BookRequest.PublishedDate);
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    _ => books
                };
                var result = await Task.WhenAll((
                    books.Select(async book =>
                    {
                        return new GetBookDto()
                        {
                            Author = book.Author.Name.firtName + ' ' + book.Author.Name.LastName,
                            Title = book.Title,
                            Cover = book.Cover,
                            access = book.Access.ToString(),
                        };

                    })));
                return result;
            }
            return Error.NotFound(description: "SearchMode is invalid");
        }
    }
}
