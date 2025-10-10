//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using ErrorOr;

//using Generita.Application.Common.Interfaces.Repository;
//using Generita.Application.Common.Messaging;
//using Generita.Domain.Models;

//namespace Generita.Application.Books.Commands.AddBook
//{
//    public class AddBookHandler : ICommandHandler<AddBookCommand>
//    {
//        private IBookRepository _bookRepository;

//        public AddBookHandler(IBookRepository bookRepository)
//        {
//            _bookRepository = bookRepository;
//        }

//        public async Task<ErrorOr<Success>> Handle(AddBookCommand request, CancellationToken cancellationToken)
//        {
//            var book = new Book(Guid.NewGuid())
//            {
//                Title = request.AddBookDto.Title,
//                Synopsis = request.AddBookDto.Synopsis,
//                PublishedDate = request.AddBookDto.PublishedDate,
//                AuthorId = request.AddBookDto.AuthorId,
//                Cover = request.AddBookDto.Cover,
//                FilePath = request.AddBookDto.FilePath,
//                ImagePath = request.AddBookDto.ImagePath,
//                CategoryId = request.AddBookDto.CategoryId,
//                Access = request.AddBookDto.Subscription,
//            };
//            await _bookRepository.Add(book);
//            return Result.Success;

//        }
//    }
//}
