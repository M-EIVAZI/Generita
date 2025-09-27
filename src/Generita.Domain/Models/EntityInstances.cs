using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class EntityInstances : BaseEntity
    {
        public EntityInstances(Guid id) : base(id)
        {
            
        }
        public string sample {  get; set; }
        public Guid EntityId { get; set; }
        public Guid ParagraphId { get; set; }
        public int Position {  get; set; }
        public virtual Entity Entity { get; set; }
        public virtual Paragraph Paragraph { get; set; }
    }
}
