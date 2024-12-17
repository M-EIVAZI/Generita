using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

using Generita.Domain.Enums;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class Songs
{
    public Guid Id { get; set; }
    public Name Name { get; set; }
    public Guid CategoryId { get; set; }
    public TimeSpan Duration { get; set; }
    public DateOnly CreateAt { get; set; }
    public DateOnly UpdateAt { get; set; }
    public string FilePath { get; set; }
    public OwnerShip Owner { get; set}
    public virtual ICollection<BookSong> BookSongs { get; set; }
    public virtual SongCategory Category { get; set; }
}