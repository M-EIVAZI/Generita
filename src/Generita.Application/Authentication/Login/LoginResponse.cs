using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32.SafeHandles;

namespace Generita.Application.Authentication.Login
{
    public class LoginResponse
    {
        public string accessToken {get;set;}
        public string refreshToken { get;set;}

    }
}
