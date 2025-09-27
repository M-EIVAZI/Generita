using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class Entity:BaseEntity
{
    public Entity(Guid Id) : base(Id)
    {
    }

    public string type { get; set; }
    public Guid MusicId { get; set; }
    public virtual Songs Songs { get; set; }
    public virtual ICollection<EntityInstances> Instances { get; set; }
    //public virtual Songs Songs { get; set; }
}