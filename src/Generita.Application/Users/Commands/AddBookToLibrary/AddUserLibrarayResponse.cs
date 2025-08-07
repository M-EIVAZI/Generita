using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generita.Application.Users.Commands.AddBookToLibrary
{
    public class AddUserLibrarayResponse
    {
        public ICollection<Guid> LibraryBookIds { get; set; }
    }
}
