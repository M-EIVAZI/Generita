using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Commands.AddBook
{
    public class AddBookHandler : ICommandHandler<AddBookCommand>
    {
        private IBookRepository _bookRepository;

        public AddBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ErrorOr<Success>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.Add(request.AddBookDto);
            return Result.Success;

        }
    }
}
