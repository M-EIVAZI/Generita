using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace Generita.Application.Audios.Queries.GetEntityAudioTags
{
    internal class GetEntityAudioValidator:AbstractValidator<GetEntityAudioQuery>
       
    {
        public GetEntityAudioValidator()
        {
            RuleFor(x=>x.type).NotEmpty();
        }
    }
}
