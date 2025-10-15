using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Messaging;

using MediatR;

namespace Generita.Application.Plan.Queries.GetAllPlans
{
    public class GetAllPlansQuery:IQuery<ICollection<PlanDto>>
    {
    }
}
