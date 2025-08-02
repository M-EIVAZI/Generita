using Generita.Domain.Common.Abstractions;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class User:AggregateRoot
{
    public User(Guid Id) : base(Id)
    {
    }

    public Name Name { get; set; }
    public DateOnly CreateAt{ get; set; }
    public DateOnly UpdateAt{ get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public virtual ICollection<Transactions> Transactions { get; set; }
    public virtual ICollection<Views> Views { get; set; }
}