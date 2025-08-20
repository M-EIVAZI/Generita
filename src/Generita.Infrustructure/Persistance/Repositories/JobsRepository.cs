using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces;
using Generita.Domain.Common.Interfaces;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    public class JobsRepository : IJobRepository
    {
        private GeneritaDbContext _db;
        private IUnitOfWork _unitOfWork;

        public JobsRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Jobs value)
        {
            await _db.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var job=await  GetById(id);
            if (job == null) 
                return false;
            else
            {
                _db.Jobs.Remove(job);
                return true;
            }

        }

        public async Task<ICollection<Jobs>> GetAll()
        {
            return await _db.Jobs.ToListAsync();
        }

        public async Task<Jobs> GetById(Guid id)
        {
            return await _db.Jobs.FirstOrDefaultAsync(x => x.Id == id);
                
        }

        public Task<bool> Update(Jobs value)
        {
            _db.Update(value);
            return Task.FromResult(true);
        }
        public async Task<Jobs> GetByBookId(Guid bookId)
        {
            return await _db.Jobs.FirstOrDefaultAsync(x => x.BookId == bookId);

        }
    }
}
