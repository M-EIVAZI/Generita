using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Home.Query
{
    public record HomeQuery : ICachedQuery<HomeResponse>
    {
        public string Key => "Home";

        public TimeSpan? Time =>TimeSpan.FromMinutes(30);
    }
}
