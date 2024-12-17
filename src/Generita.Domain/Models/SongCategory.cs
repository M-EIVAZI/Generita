namespace Generita.Domain.Models;

public class SongCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Songs> Songs { get; set; }
}