using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

namespace Generita.Application.Authors.GetStatusByJobId
{
    public record GetStatusByJobIdQuery(Guid jobId):IQuery<GetStatusByJobIdResponse>
    {
    }
}
