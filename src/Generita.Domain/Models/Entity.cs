using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class Entity:BaseEntity
{
    public Entity(Guid Id) : base(Id)
    {
    }

    public string type { get; set; }
    public string sample { get; set; }
    public int Position { get; set; }
    public Guid ParagraphId { get; set; }
    public Guid MusicId { get; set; }
    public virtual Paragraph Paragraph { get; set; }
    public virtual Songs Songs { get; set; }
    public virtual CanonicalEntity EntityInstances { get; set; }
    //public virtual Songs Songs { get; set; }
}