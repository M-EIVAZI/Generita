using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;
using Generita.Domain.Common.Enums;

namespace Generita.Domain.Models
{
    public class Jobs:BaseEntity
    {
        public Jobs(Guid id) : base(id)
        {
        }

        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }
        public JobStatus JobStatus { get; set; }
        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }

    }
}
