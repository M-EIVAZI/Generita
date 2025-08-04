using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Authentication.Me
{
    public class MeResponseSubscription
    {
        public string status { get; set; }
        public DateOnly ExpiryDate { get; set; }
    }
}
