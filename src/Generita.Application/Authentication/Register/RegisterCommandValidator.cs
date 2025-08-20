using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using FluentValidation;

namespace Generita.Application.Authentication.Register
{
    public  partial  class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        private static readonly Regex StrongPasswordRegex = new Regex(
            "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            RegexOptions.Compiled);
        public RegisterCommandValidator()
        {
            RuleFor(x=>x.registerDto.email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.registerDto.password)
                .NotEmpty()
                .Matches(StrongPasswordRegex)
                .WithMessage("Password must be at least 8 characters, contain uppercase, lowercase, number and special character.");


            RuleFor(x => x.registerDto.name)
                .NotEmpty()
                .MinimumLength(50);

        }
    }
}
