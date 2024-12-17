namespace Generita.Domain.Models;

public class BookCategory
{
    public int id { get; set; }
    public string CategoryName { get; set; }
    public virtual ICollection<Books> Books { get; set; }
}