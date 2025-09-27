using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private GeneritaDbContext _context;

        public EntityRepository(GeneritaDbContext context)
        {
            _context = context;
        }

        public async Task Add(Entity value)
        {
            await _context.Entity.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = _context.Entity.FirstOrDefaultAsync(x=>x.Id==id);
            if (entity is null)
                return false;

             _context.Remove(entity);
            return true;
        }

        public async Task<ICollection<Entity>> GetAll()
        {
            return await _context.Entity.ToListAsync();
        }

        public async Task<Entity> GetById(Guid id)
        {
            return await _context.Entity.FirstOrDefaultAsync(x => x.Id==id);
        }

        public Task<Entity> GetEntityByBookId(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Entity value)
        {
            _context.Entity.Update(value);
            return Task.FromResult(true);
        }
        public async Task<Entity> GetByType(string type)
        {
            return await _context.Entity.Include(x => x.Songs).FirstOrDefaultAsync(x => x.type == type);
        }

        public async Task AddEntityInstancesRange(ICollection<EntityInstances> entity)
        {
            await _context.EntityInstances.AddRangeAsync(entity);
        }
    }
}
