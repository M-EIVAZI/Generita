
using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class BookCategory:BaseEntity
{
    public BookCategory(Guid id) : base(id)
    {
    }

    public string CategoryName { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}