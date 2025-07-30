using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class BookCategory:BaseEntity
{
    public int id { get; set; }
    public string CategoryName { get; set; }
    public virtual ICollection<Books> Books { get; set; }
}