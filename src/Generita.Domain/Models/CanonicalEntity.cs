using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class CanonicalEntity : BaseEntity
    {
        public CanonicalEntity(Guid id) : base(id)
        {
        }
        public string Type { get; set; }
        public virtual ICollection<CanonicalEntityVariant> Variants { get; set; }
    }
}
