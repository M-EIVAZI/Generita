using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Generita.Application.Books.Queries.GetBookContent
{
    internal class GetBookContentValidator:AbstractValidator<GetBookByContentQuery>
    {
        public GetBookContentValidator()
        {
            RuleFor(x=>x.bookId).NotEmpty();
        }
    }
}
