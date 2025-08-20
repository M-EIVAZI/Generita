using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Application.Common.Services;
using Generita.Domain.Common.Interfaces;

namespace Generita.Application.Authors.AddBook
{
    internal class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private IBookRepository _bookRepository;
        private IBookService _bookService;
        private IUnitOfWork _unitOfWork;

        public AddBookCommandHandler(IBookRepository bookRepository, IBookService bookService, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _bookService = bookService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Success>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            PostJobRequest jobRequest = new() { Title = request.Dto.Title, allowed_ages = request.Dto.AgeClasses, allowed_senses = request.Dto.MusicSense, target_abstracts = request.Dto.Entities };
            var postresponse = await _bookService.PostBook(jobRequest);
            if (postresponse.Errors.Any())
                return postresponse.Errors;
            var book = postresponse.Value;
            throw new NotImplementedException();
        }
    }
}
