using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class Author
{
    public Guid Id { get; set; }
    public Name Name { get; set; }
    public DateOnly BirthDate { get;}
    public string Nationality { get; set;} 
    public virtual ICollection<Books> Books { get; set; }
    public virtual ICollection<Entity> Entities { get; set; }
}