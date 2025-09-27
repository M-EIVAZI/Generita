using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Abstractions;
using Generita.Domain.Common.Enums;

namespace Generita.Domain.Models
{
    public class Paragraph : BaseEntity
    {
        public Paragraph(Guid id) : base(id)
        {
        }
        public string Text { get; set; }
        public AgeClasses AgeClass { get; set; }
        public MusicSense MusicSense { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; } 
        public Guid SongId { get; set; }
        public Songs Songs { get; set; }
        public ICollection<EntityInstances> EntityInstances { get; set; }
    }
}
