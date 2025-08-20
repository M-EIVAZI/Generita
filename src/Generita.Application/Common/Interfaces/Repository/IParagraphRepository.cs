using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IParagraphRepository : IGenericRepository<Paragraph>
    {
        Task AddList(IEnumerable<Paragraph> list);
        Task<ICollection<Paragraph>> GetByBookId(Guid bookId);
        Task<Paragraph> GetBySenseAndAge(MusicSense sense, AgeClasses age);
    }
}
