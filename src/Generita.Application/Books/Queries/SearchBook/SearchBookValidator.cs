using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Generita.Application.Books.Queries.SearchBook
{
    internal class SearchBookValidator:AbstractValidator<SearchBookQuery>
    {
        public SearchBookValidator()
        {
            RuleFor(x => (int)x.BookRequest.Order)
                .InclusiveBetween(0, 4).NotEmpty();
            RuleFor(x=>(int)x.BookRequest.SearchMode)
                .InclusiveBetween(0,3).NotEmpty();
            RuleFor(x => x)
                .Must(x => !string.IsNullOrWhiteSpace(x.BookRequest.Name) || x.BookRequest.PublishedDate != DateOnly.MinValue)
                .WithMessage("Either Name or Date must be provided.");
            

        }
    }
}
