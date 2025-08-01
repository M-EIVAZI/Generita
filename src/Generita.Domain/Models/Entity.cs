using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class Entity:AggregateRoot
{
    protected Entity(Guid Id) : base(Id)
    {
    }

    public string Name { get; set; }
    public ICollection<string> Descriptions { get; set; }
    public Guid SongId {get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public virtual Songs Song { get; set; }
    //public virtual Songs Songs { get; set; }
}