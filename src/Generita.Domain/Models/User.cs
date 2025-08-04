using Generita.Domain.Common.Abstractions;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class User:AggregateRoot
{
    public User(Guid Id) : base(Id)
    {
    }

    public string Name { get; set; }
    public DateTime CreateAt{ get; set; }
    public DateTime UpdateAt { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public virtual ICollection<Transactions> Transactions { get; set; }
    public virtual ICollection<Views> Views { get; set; }
    public virtual ICollection<RefreshTokens> RefreshTokens { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}