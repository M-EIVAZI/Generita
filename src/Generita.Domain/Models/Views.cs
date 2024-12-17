using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Domain.Models
{
    public class Views
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime ViewAt { get; set; }
    }
}
