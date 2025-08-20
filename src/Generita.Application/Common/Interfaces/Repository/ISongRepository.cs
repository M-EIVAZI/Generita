using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface ISongRepository : IGenericRepository<Songs>
    {
        Task<Songs> GetByEntityType(string type);
        Task<Songs> GetBySenseAndAge(MusicSense musicSense, AgeClasses ageClasses);
    }
}
