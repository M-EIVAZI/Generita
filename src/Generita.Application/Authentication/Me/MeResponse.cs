using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Authentication.Me
{
    public class MeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public MeResponseSubscription? Subscription { get; set; }
        public ICollection<Guid> LibraryBookIds { get; set; }
    }
}
