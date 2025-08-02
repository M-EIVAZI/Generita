using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

using Generita.Domain.Common.Abstractions;
using Generita.Domain.Enums;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class Songs:AggregateRoot
{
    public Songs(Guid Id) : base(Id)
    {
    }

    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public TimeSpan Duration { get; set; }
    public DateOnly CreateAt { get; set; }
    public DateOnly UpdateAt { get; set; }
    public string FilePath { get; set; }
    public OwnerShip Owner { get; set; }
    public Entity Entity { get; set; }
    public virtual ICollection<Book> Books { get; set; }
    public virtual SongCategory Category { get; set; }
}