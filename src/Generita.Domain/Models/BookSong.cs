using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Domain.Models
{
    public class BookSong
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Guid SongId { get; set; }
        public virtual Books Book { get; set; }
        public virtual Songs Song { get; set; }
    }
}
