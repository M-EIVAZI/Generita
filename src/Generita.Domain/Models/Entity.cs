namespace Generita.Domain.Models;

public class Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<string> Descriptions { get; set; }
    public Author AuthorId {get; set; }
    public virtual Author Author { get; set; }
}