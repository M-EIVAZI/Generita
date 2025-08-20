using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IEntityRepository:IGenericRepository<Entity>
    {
        Task<Entity> GetByType(string type);
        Task<Entity> GetEntityByBookId(int bookId);
        Task AddCanonicalEntityRange(ICollection<CanonicalEntity> entity);
    }
}
