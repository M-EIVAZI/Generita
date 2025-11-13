using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Events;

using MediatR;

namespace Generita.Application.Books.Commands.RemoveBook
{
    public class RemoveBookHandler : ICommandHandler<RemoveBookCommand>
    {
        private IBookRepository _bookRepository;
        private IUnitOfWork _unitOfWork;
        private IJobRepository _jobRepository;
        private IPublisher _publisher;

        public RemoveBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork, IJobRepository jobRepository, IPublisher publisher)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _jobRepository = jobRepository;
            _publisher = publisher;
        }

        public async Task<ErrorOr<Success>> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var job = await _jobRepository.GetById(request.Id);
                await _bookRepository.Delete(request.Id);
                await _unitOfWork.CommitAsync();
                BookRemovedEvent BookRemoved=new()
                { BookId = request.Id };
                await _publisher.Publish(BookRemoved, cancellationToken);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }


        }
    }
}
