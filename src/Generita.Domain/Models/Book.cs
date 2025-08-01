using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models;

public class Book:AggregateRoot
{
    protected Book(Guid Id) : base(Id)
    {
    }

    public string Title { get; set; }
    public DateOnly PublishedDate { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
    public string Synopsis { get; set; }
    public string Cover {  get; set; }
    public string Subscription { get; set; }
    public virtual Author Author { get; set; }
    public virtual BookCategory BookCategory { get; set; }
    public string FilePath { get; set; }
    public string ImagePath { get; set; }
    public virtual ICollection<Songs> Songs { get; set; }
    public virtual Entity Entity { get; set; }


}