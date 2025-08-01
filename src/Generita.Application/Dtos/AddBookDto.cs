using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Books.Commands.AddBook;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Models;

namespace Generita.Application.Dtos
{
    public class AddBookDto 
    {
        public string Title { get; set; }
        public DateOnly PublishedDate { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public string Synopsis { get; set; }
        public string Cover { get; set; }
        public string Subscription { get; set; }
        public string FilePath { get; set; }
        public string ImagePath { get; set; }
    }
}
