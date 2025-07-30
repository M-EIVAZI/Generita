using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class Views:BaseEntity
    {
        protected Views(Guid id) : base(id)
        {
        }

        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime ViewAt { get; set; }
    }
}
