using Generita.Domain.Common.Abstractions;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class Author:AggregateRoot
{
    public Author(Guid id) : base(id)
    {
    }

    public string Name { get; set; }
    public DateOnly BirthDate { get;}
    public int age { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Nationality { get; set;} 
    public virtual ICollection<Jobs> jobs { get; set; }
    public virtual ICollection<Book> Books { get; set; }
    public virtual ICollection<RefreshTokens> refreshTokens { get; set; }
}