using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class SongCategory:BaseEntity
{
    public SongCategory(Guid id) : base(id)
    {
    }

    public string Name { get; set; }
    public virtual ICollection<Songs> Songs { get; set; }
}