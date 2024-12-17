using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Domain.Models
{
    public class UserPlan
    {
        public Guid Id { get; set; }
        public Guid PlanId { get; set; }
        public Guid TransationId { get; set; }
        public DateOnly CreateAt { get; set; }
        public DateOnly EndsAt { get; set; }
        public virtual Plans Plan { get; set; }
        public virtual Transactions Transactions { get; set; }

    }
}
