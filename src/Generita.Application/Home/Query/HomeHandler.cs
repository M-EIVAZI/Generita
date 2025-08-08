using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Models;

namespace Generita.Application.Home.Query
{
    public class HomeHandler : IQueryHandler<HomeQuery, HomeResponse>
    {
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;
        private IAuthorRepository _authorRepository;
        private IBookCategoryRepository _bookCategoryRepository;

        public HomeHandler(IBookRepository bookRepository, IUserRepository userRepository, IAuthorRepository authorRepository, IBookCategoryRepository bookCategoryRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            _authorRepository = authorRepository;
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task<ErrorOr<HomeResponse>> Handle(HomeQuery request, CancellationToken cancellationToken)
        {
           var  bannerbooks =await _userRepository.GetPopularBooks();
            var featuredbooks = await _bookRepository.GetNewestBooks();
            var subsciptiononly = await _bookRepository.GetSubscriptionOnly();
            var freeonly=await _bookRepository.GetFreeOnly();
            var bannerhomebooksTasks = bannerbooks.Select(async x =>
            {
                var author = await _authorRepository.GetById(x.Book.AuthorId);
                var category=await _bookCategoryRepository.GetById(x.Book.CategoryId);
                return new HomeBookDto()
                {
                    AuthorName=author.Name.firtName+' '+author.Name.LastName,
                    Title=x.Book.Title,
                    Access=x.Book.Access.ToString(),
                    CategoryName=category.CategoryName,
                    Cover=x.Book.Cover,
                    FilePath=x.Book.FilePath,
                    Id=x.Book.Id,
                    ImagePath=x.Book.ImagePath,
                    PublishedDate=x.Book.PublishedDate,
                    Synopsis = x.Book.Synopsis

                };

            });
            var bannerhomebooks = await Task.WhenAll(bannerhomebooksTasks);
            HomeResponse res = new HomeResponse()
            {
                BannerBook=bannerhomebooks,
                Featured=featuredbooks.Select(x=>
                {
                    return new HomeBookDto()
                    {
                        AuthorName = x.Author.Name.firtName + ' ' + x.Author.Name.LastName,
                        Title = x.Title,
                        Access = x.Access.ToString(),
                        CategoryName = x.BookCategory.CategoryName,
                        Cover = x.Cover,
                        FilePath = x.FilePath,
                        Id = x.Id,
                        ImagePath = x.ImagePath,
                        PublishedDate = x.PublishedDate,
                        Synopsis = x.Synopsis
                    };
                }).ToList(),
                SubscriptionOnly=subsciptiononly.Select(x=>
                {
                    return new HomeBookDto()
                    {
                        AuthorName = x.Author.Name.firtName + ' ' + x.Author.Name.LastName,
                        Title = x.Title,
                        Access = x.Access.ToString(),
                        CategoryName = x.BookCategory.CategoryName,
                        Cover = x.Cover,
                        FilePath = x.FilePath,
                        Id = x.Id,
                        ImagePath = x.ImagePath,
                        PublishedDate = x.PublishedDate,
                        Synopsis = x.Synopsis
                    };
                }).ToList(),
                FreeOnly=freeonly.Select(x=>
                {
                    return new HomeBookDto()
                    {
                        AuthorName = x.Author.Name.firtName + ' ' + x.Author.Name.LastName,
                        Title = x.Title,
                        Access = x.Access.ToString(),
                        CategoryName = x.BookCategory.CategoryName,
                        Cover = x.Cover,
                        FilePath = x.FilePath,
                        Id = x.Id,
                        ImagePath = x.ImagePath,
                        PublishedDate = x.PublishedDate,
                        Synopsis = x.Synopsis
                    };
                }).ToList(),
            };
            return res;
        }
    }
}
