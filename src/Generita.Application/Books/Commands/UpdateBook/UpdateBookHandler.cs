using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Common.Interfaces;

namespace Generita.Application.Books.Commands.UpdateBook
{
    public class UpdateBookHandler : ICommandHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Success>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _bookRepository.Update(request.books);
                await _unitOfWork.CommitAsync(cancellationToken);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Failure("UpdateFails",ex.Message);
            }

        }
    }
}
