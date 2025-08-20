using Generita.Domain.Common.Enums;

namespace Generita.Application.Authors.AddBook
{
    public class AuthorAddBookDto
    {
        public string Title { get; set; }
        public IEnumerable<AgeClasses> AgeClasses { get; set; }
        public IEnumerable<MusicSense> MusicSense { get; set; }
        public ICollection<Dictionary<string, string>> Entities { get; set; }
    }
}
