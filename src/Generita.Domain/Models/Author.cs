using Generita.Domain.Common.Abstractions;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class Author:AggregateRoot
{
    protected Author(Guid id) : base(id)
    {
    }

    public Name Name { get; set; }
    public DateOnly BirthDate { get;}
    public string Nationality { get; set;} 
    public virtual ICollection<Books> Books { get; set; }
    public virtual ICollection<Entity> Entities { get; set; }
}