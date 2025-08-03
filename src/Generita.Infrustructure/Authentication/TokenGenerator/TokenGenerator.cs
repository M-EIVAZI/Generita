using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces;
using Generita.Domain.Models;

namespace Generita.Infrustructure.Authentication.TokenGenerator
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
