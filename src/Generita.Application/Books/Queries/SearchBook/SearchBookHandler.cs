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
            if (request.BookRequest.SearchMode == SearchMode.ByAllFields)
            {
                ICollection<Book> books;

                if (request.BookRequest.PublishedDate is not null && request.BookRequest.PublishedDate.Value > DateOnly.MinValue)
                    books = await _bookRepository.SearchAllFields(
                        request.BookRequest.Name.ToLower(),
                        request.BookRequest.PublishedDate
                    );
                else
                    books = await _bookRepository.SearchAllFields(request.BookRequest.Name.ToLower());

                // سپس Ordering و Mapping مثل سایر حالت‌ها
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));

                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0).ToList(),
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    SearchResultOrder.TitleAToZ => books.OrderBy(b => b.Title.ToLower()).ToList(),
                    SearchResultOrder.TitleZToA => books.OrderByDescending(b => b.Title.ToLower()).ToList(),
                    _ => books
                };

                var res = await Task.WhenAll(books.Select(async b => new GetBookDto
                {
                    id = b.Id,
                    title = b.Title,
                    authorName = b.Author.Name,
                    categoryName = b.BookCategory.CategoryName,
                    cover = b.Cover,
                    synopsis = b.Synopsis,
                    access = b.Access.ToString()
                }));

                return res;
            }

            else if (request.BookRequest.SearchMode == SearchMode.ByTitle)
            {
                ICollection<Book> books;
                if (request.BookRequest.PublishedDate is null && request.BookRequest.PublishedDate.Value > DateOnly.MinValue)
                    books = await _bookRepository.SearchBook(request.BookRequest.Name, request.BookRequest.PublishedDate);
                else
                    books = await _bookRepository.SearchBook(request.BookRequest.Name);

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
                    SearchResultOrder.TitleAToZ => books.OrderBy(b => b.Title.ToLower()).ToList(),
                    SearchResultOrder.TitleZToA => books.OrderByDescending(b => b.Title.ToLower()).ToList(),
                    _ => books
                };
                var result = new List<GetBookDto>();

                foreach (var b in books)
                {
                    var author = await _authorRepository.GetById(b.AuthorId);
                    var category = await _categoryRepository.GetById(b.CategoryId);

                    result.Add(new GetBookDto
                    {
                        id = b.Id,
                        title = b.Title,
                        authorName = author.Name,
                        categoryName = category.CategoryName,
                        cover = b.Cover,
                        synopsis = b.Synopsis,
                        access = b.Access.ToString()
                    });
                }
                return result;

            }
            else if (request.BookRequest.SearchMode == SearchMode.ByCategory)
            {
                ICollection<BookCategory> catbooks;
                if (request.BookRequest.PublishedDate is null && request.BookRequest.PublishedDate.Value > DateOnly.MinValue)
                    catbooks = await _categoryRepository.GetByName(request.BookRequest.Name, request.BookRequest.PublishedDate);
                else
                    catbooks = await _categoryRepository.GetByName(request.BookRequest.Name);
                var books = catbooks.SelectMany(x=>x.Books).ToList();
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    SearchResultOrder.TitleAToZ => books.OrderBy(b => b.Title.ToLower()).ToList(),
                    SearchResultOrder.TitleZToA => books.OrderByDescending(b => b.Title.ToLower()).ToList(),
                    _ => books
                };
                var result = new List<GetBookDto>();

                foreach (var b in books)
                {
                    var author = await _authorRepository.GetById(b.AuthorId);
                    var category = await _categoryRepository.GetById(b.CategoryId);

                    result.Add(new GetBookDto
                    {
                        id = b.Id,
                        title = b.Title,
                        authorName = author.Name,
                        categoryName = category.CategoryName,
                        cover = b.Cover,
                        synopsis = b.Synopsis,
                        access = b.Access.ToString()
                    });
                }
                return result;
            }
            else if(request.BookRequest.SearchMode==SearchMode.ByAuthorName)
            {
                Author? authors;
                if (request.BookRequest.PublishedDate is null && request.BookRequest.PublishedDate.Value > DateOnly.MinValue)
                    authors = await _authorRepository.GetByAuthorName(request.BookRequest.Name, request.BookRequest.PublishedDate);
                else
                    authors = await _authorRepository.GetByAuthorName(request.BookRequest.Name);
                //var authors = await _authorRepository.GetByAuthorName(request.BookRequest.Name);
                if (authors == null)
                    return new List<GetBookDto>();
                if(authors.Books ==null)
                    return new List<GetBookDto>();
                var books = authors.Books;
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.ByOldest => books.OrderBy(b => b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest => books.OrderByDescending(b => b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.Random => books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    SearchResultOrder.TitleAToZ => books.OrderBy(b => b.Title.ToLower()).ToList(),
                    SearchResultOrder.TitleZToA => books.OrderByDescending(b => b.Title.ToLower()).ToList(),
                    _ => books
                };
                var result = new List<GetBookDto>();

                foreach (var b in books)
                {
                    var author = await _authorRepository.GetById(b.AuthorId);
                    var category = await _categoryRepository.GetById(b.CategoryId);

                    result.Add(new GetBookDto
                    {
                        id = b.Id,
                        title = b.Title,
                        authorName = author.Name,
                        categoryName = category.CategoryName,
                        cover = b.Cover,
                        synopsis = b.Synopsis,
                        access = b.Access.ToString()
                    });
                }
                return result;
            }
            else if(request.BookRequest.SearchMode ==SearchMode.BySynopsis)
            {
                ICollection<Book> books;
                if (request.BookRequest.PublishedDate is not null && request.BookRequest.PublishedDate.Value > DateOnly.MinValue)
                    books = await _bookRepository.GetBySynopsis(request.BookRequest.Name, request.BookRequest.PublishedDate);
                else
                    books = await _bookRepository.GetBySynopsis(request.BookRequest.Name);
                var likes = await _bookRepository.GetLikesNumber(books.Select(x => x.Id));
                books = request.BookRequest.Order switch
                {
                    SearchResultOrder.Random=>books.OrderBy(_ => Guid.NewGuid()).ToList(),
                    SearchResultOrder.ByOldest=>books.OrderBy(b=>b.PublishedDate).ToList(),
                    SearchResultOrder.ByNewest=>books.OrderByDescending(b=>b.PublishedDate).ToList(),
                    SearchResultOrder.MostLikes => [.. books.OrderByDescending(b => likes.TryGetValue(b.Id, out var likeCount) ? likeCount : 0)],
                    SearchResultOrder.TitleAToZ => books.OrderBy(b => b.Title.ToLower()).ToList(),
                    SearchResultOrder.TitleZToA => books.OrderByDescending(b => b.Title.ToLower()).ToList(),
                    _ => books,
                };

                var result = new List<GetBookDto>();

                foreach (var b in books)
                {
                    var author = await _authorRepository.GetById(b.AuthorId);
                    var category = await _categoryRepository.GetById(b.CategoryId);

                    result.Add(new GetBookDto
                    {
                        id = b.Id,
                        title = b.Title,
                        authorName = author.Name,
                        categoryName = category.CategoryName,
                        cover = b.Cover,
                        synopsis = b.Synopsis,
                        access = b.Access.ToString()
                    });
                }
                return result;
            }
            return Error.NotFound(description: "SearchMode is invalid");
        }
    }
}
