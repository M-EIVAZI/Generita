using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);

    }
}
