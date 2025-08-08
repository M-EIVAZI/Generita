using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;
using Generita.Domain.Models;

namespace Generita.Application.Home.Query
{
    public class HomeResponse
    {
        public ICollection<HomeBookDto> BannerBook { get; set; }
        public ICollection<HomeBookDto> Featured {  get; set; }
        public ICollection<HomeBookDto> SubscriptionOnly { get; set; }
        public ICollection<HomeBookDto> FreeOnly { get; set; }
    }
}
