using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Security.AccessControl;

using Generita.Domain.Common.Abstractions;
using Generita.Domain.Common.Enums;
using Generita.Domain.Enums;
using Generita.Domain.ValueObjects;

namespace Generita.Domain.Models;

public class Songs:AggregateRoot
{
    public Songs(Guid Id) : base(Id)
    {
    }

    public string Name { get; set; }
    //public Guid CategoryId { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public string FilePath { get; set; }
    public OwnerShip Owner { get; set; }
    public MusicSense Music { get; set; }
    public AgeClasses AgeClasses { get; set; }
    public string? EntityType { get; set; }
    public ICollection<Paragraph> Paragraphs { get; set; }
    public ICollection<Entity> Entity { get; set; }
    public virtual ICollection<Book> Books { get; set; }
    //public virtual SongCategory Category { get; set; }
}