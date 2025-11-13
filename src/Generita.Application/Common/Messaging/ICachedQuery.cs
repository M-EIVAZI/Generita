using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Common.Messaging
{
    public interface ICachedQuery
    {
        string Key { get; }
        TimeSpan? Time { get; }
    }

    public interface ICachedQuery<TResponse> : ICachedQuery, IQuery<TResponse>
    {
    }
}
