using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Messaging
{
    public interface ICacheInvalidationCommand
    {
        IEnumerable<string> KeysToInvalidate { get; }
    }
}
