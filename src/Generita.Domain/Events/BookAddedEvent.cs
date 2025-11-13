using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Generita.Domain.Events
{
    public class BookAddedEvent:INotification
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
    }
}
