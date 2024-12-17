namespace Generita.Domain.Models;

public class Books
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateOnly PublishedDate { get; set; }
    public Guid AuthorId { get; set; }
    public int CategoryId { get; set; }
    public virtual Author Author { get; set; }
    public virtual BookCategory BookCategory { get; set; }
    public string FilePath { get; set; }
    public string ImagePath { get; set; }
    public virtual ICollection<BookSong> BookSongs { get; set; }


}