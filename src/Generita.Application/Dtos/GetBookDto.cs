using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.ValueObjects;

namespace Generita.Application.Dtos
{
    public class GetBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }  
        public string Cover { get; set; }
        public string synopsis { get; set; }
        public string access { get; set; }
    }
}
