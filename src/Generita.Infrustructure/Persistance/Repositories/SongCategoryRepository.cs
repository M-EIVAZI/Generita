using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class SongCategoryRepository : ISongCategoryRepository
    {
        private GeneritaDbContext _context;

        public SongCategoryRepository(GeneritaDbContext context)
        {
            _context = context;
        }

        public async Task Add(SongCategory value)
        {
            await _context.SongCategory.AddAsync(value);
        }

        public async  Task<bool> Delete(Guid id)
        {
            var cat = await _context.SongCategory.FindAsync(id);
            if (cat is null)
                return false;
            _context.SongCategory.Remove(cat);
            return true;

        }

        public async Task<ICollection<SongCategory>> GetAll()
        {
            return await _context.SongCategory.ToListAsync();
        }

        public async Task<SongCategory> GetById(Guid id)
        {
            return await _context.SongCategory.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(SongCategory value)
        {
            _context.Update(value);
            return Task.FromResult(true);
        }
    }
}
