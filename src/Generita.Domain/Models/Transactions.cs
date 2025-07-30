using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Enums;

namespace Generita.Domain.Models
{
    public class Transactions:Entity
    {
        protected Transactions(Guid Id) : base(Id)
        {
        }

        public Guid UserId { get; set; }
        public DateOnly CreateAt {  get; set; }
        public DateOnly UpdateAt { get; set; }
        public int Price { get; set; }
        public States States { get; set; }
        public virtual User User { get; set; }
    }
}
