using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

namespace Generita.Application.Common.Dtos
{
    public class BannerBookDto
    {
          public int UserCount {  get; set; }
        public Book Book { get; set; }
    }
}
