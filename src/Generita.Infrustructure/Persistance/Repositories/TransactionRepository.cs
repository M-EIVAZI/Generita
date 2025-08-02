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
    class TransactionRepository : ITransactionsRepository
    {
        private GeneritaDbContext _context;

        public TransactionRepository(GeneritaDbContext context)
        {
            _context = context;
        }

        public async Task Add(Transactions value)
        {
            await  _context.Transactions.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var transaction=await _context.Transactions.FindAsync(id);
            if (transaction is null)
                return false;
            _context.Transactions.Remove(transaction);
            return true;
        }

        public async Task<ICollection<Transactions>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transactions> GetById(Guid id)
        {
            return await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(Transactions value)
        {
            _context.Transactions.Update(value);
            return Task.FromResult(true);
        }
    }
}
