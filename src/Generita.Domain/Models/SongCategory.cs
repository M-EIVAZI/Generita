using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class SongCategory:BaseEntity
{
    protected SongCategory(Guid id) : base(id)
    {
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Songs> Songs { get; set; }
}