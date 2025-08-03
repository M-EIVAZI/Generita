using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private GeneritaDbContext _context;

        public RefreshTokenRepository(GeneritaDbContext context)
        {
            _context = context;
        }

        public async Task Add(RefreshTokens value)
        {
            await _context.RefreshTokens.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var rt=await _context.RefreshTokens.FirstOrDefaultAsync(x=>x.Id==id);
            if(rt is null) return false;
            _context.RefreshTokens.Remove(rt);
            return true;
        }

        public async Task<ICollection<RefreshTokens>> GetAll()
        {
            return await _context.RefreshTokens.ToListAsync();
        }

        public async Task<RefreshTokens> GetById(Guid id)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(RefreshTokens value)
        {
            _context.RefreshTokens.Update(value);
            return Task.FromResult(true);
        }
    }
}
