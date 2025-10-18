using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces;

namespace Generita.Infrustructure.Authentication
{
    public partial class PasswordHasher : IPasswordHasher
    {
        private static readonly Regex PasswordRegex = StrongPasswordRegex();

        public ErrorOr<string> HashPassword(string password)
        {
            return !PasswordRegex.IsMatch(password)
                ? Error.Validation(description: "Password's too weak,Must contain at least one word and one number ant be at least 6 characters")
                : BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool IsCorrectPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }

        [GeneratedRegex("^(?=.*[A-Za-z])(?=.*\\d).{6,}$", RegexOptions.Compiled)]
        private static partial Regex StrongPasswordRegex();
    }
}
