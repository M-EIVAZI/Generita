
using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class BookCategory:BaseEntity
{
    protected BookCategory(Guid id) : base(id)
    {
    }

    public int id { get; set; }
    public string CategoryName { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}