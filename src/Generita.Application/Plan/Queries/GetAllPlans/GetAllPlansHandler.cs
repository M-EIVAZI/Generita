using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Plan.Queries.GetAllPlans
{
    internal class GetAllPlansHandler : IQueryHandler<GetAllPlansQuery, ICollection<PlanDto>>
    {
        private IPlansRepository _plansRepository;

        public GetAllPlansHandler(IPlansRepository plansRepository)
        {
            _plansRepository = plansRepository;
        }

        public async Task<ErrorOr<ICollection<PlanDto>>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
        {
            var plans = await _plansRepository.GetAll();
            return plans.Select(x => new PlanDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Duration = x.Duration,
                Price = x.Price

            }).ToList();
        }
    }
}
