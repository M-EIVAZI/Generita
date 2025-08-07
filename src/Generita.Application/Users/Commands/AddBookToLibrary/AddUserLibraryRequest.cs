using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Users.Commands.AddBookToLibrary
{
    public class AddUserLibraryRequest
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
    }
}
