using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class CanonicalEntityVariant : BaseEntity
    {
        public CanonicalEntityVariant(Guid id) : base(id)
        {
        }

        public string Value { get; set; }

        public Guid CanonicalEntityId { get; set; }
        public CanonicalEntity CanonicalEntity { get; set; }
    }
}
