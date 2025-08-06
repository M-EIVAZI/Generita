using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class BookLikes : BaseEntity
    {
        public BookLikes(Guid id) : base(id)
        {
        }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime CreateAt { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }

    }
}
