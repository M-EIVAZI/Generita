using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;
using Generita.Domain.Enums;

namespace Generita.Domain.Models
{
    public class Transactions : BaseEntity
    {
        public Transactions(Guid Id) : base(Id)
        {
        }

        public Guid UserId { get; set; }
        public Guid PlanId { get; set; }
        public string Authority { get; set; }
        public long? RefId {  get; set; }
        public string? car_pan { get; set; }
        public DateTime PaidAt { get; set; }
        public DateTime CreateAt {  get; set; }
        public int Price { get; set; }
        public States States { get; set; }
        public virtual User User { get; set; }
        public virtual Plans Plan { get; set; }
    }
}
