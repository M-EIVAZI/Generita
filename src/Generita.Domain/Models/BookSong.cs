using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;

namespace Generita.Domain.Models
{
    public class BookSong:BaseEntity
    {
        protected BookSong(Guid id) : base(id)
        {
        }

        public Guid BookId { get; set; }
        public Guid SongId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Songs Song { get; set; }
    }
}
