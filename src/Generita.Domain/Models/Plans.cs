using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class Plans:AggregateRoot
    {
        public Plans(Guid Id) : base(Id)
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        //Duration is in Days 
        public int Duration { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
