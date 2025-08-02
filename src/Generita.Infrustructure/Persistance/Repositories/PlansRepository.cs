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
    internal class PlansRepository : IPlansRepository
    {
        private GeneritaDbContext _db;

        public PlansRepository(GeneritaDbContext db)
        {
            _db = db;
        }

        public async Task Add(Plans value)
        {
            await _db.Plans.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var plans=await _db.Plans.FindAsync(id);
            if(plans is null)
                return false;
             _db.Plans.Remove(plans);
            return true;
        }

        public async Task<ICollection<Plans>> GetAll()
        {
            return await _db.Plans.ToListAsync();
        }

        public async Task<Plans> GetById(Guid id)
        {
            return await _db.Plans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Plans> GetPlanByName(string name)
        {
            return await _db.Plans.FirstOrDefaultAsync(x=>EF.Functions.Like(x.Name,$"%{name}%"));
        }

        public Task<bool> Update(Plans value)
        {
            _db.Plans.Update(value);
            return Task.FromResult(true);
        }
    }
}
