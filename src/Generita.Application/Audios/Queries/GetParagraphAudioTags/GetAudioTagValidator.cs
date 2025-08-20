using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

using Generita.Application.Books.Queries.SearchBook;
using Generita.Domain.Common.Enums;

namespace Generita.Application.Audios.Queries.GetParagraphAudioTags
{
    internal class GetAudioTagValidator:AbstractValidator<GetAudioTagsQuery>
    {
        public GetAudioTagValidator()
        {

            RuleFor(x => x.AudioTagsRequest.Age)
                .Must(value => Enum.TryParse<AgeClasses>(value, true, out var result)
                               && Enum.IsDefined(typeof(AgeClasses), result))
                .WithMessage("Invalid order value.");
            RuleFor(x => x.AudioTagsRequest.Age)
                .Must(value => Enum.TryParse<AgeClasses>(value, true, out var result)
                               && Enum.IsDefined(typeof(AgeClasses), result))
                .WithMessage("Invalid order value.");

        }
    }
}
