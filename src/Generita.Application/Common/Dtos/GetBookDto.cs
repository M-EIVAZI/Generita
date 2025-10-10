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
        public Guid id { get; set; }
        public string title { get; set; }
        public string authorName { get; set; }
        public string categoryName { get; set; }  
        public string cover { get; set; }
        public string synopsis { get; set; }
        public string access { get; set; }
    }
}
