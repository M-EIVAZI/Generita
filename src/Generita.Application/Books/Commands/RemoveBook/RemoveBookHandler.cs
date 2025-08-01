using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Commands.RemoveBook
{
    public class RemoveBookHandler : ICommandHandler<RemoveBookCommand>
    {
        private IBookRepository _bookRepository;

        public RemoveBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<Success>> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _bookRepository.Delete(request.Id);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return Error.Failure(description:ex.Message);
            }


        }
    }
}
