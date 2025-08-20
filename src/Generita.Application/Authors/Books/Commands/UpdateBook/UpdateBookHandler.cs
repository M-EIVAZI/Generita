using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Commands.UpdateBook
{
    public class UpdateBookHandler : ICommandHandler<UpdateBookCommand>
    {
        private IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public async Task<ErrorOr<Success>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _bookRepository.Update(request.books);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Failure("UpdateFails",ex.Message);
            }

        }
    }
}
