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
    public class AuthorRepository : IAuthorRepository
    {
        private GeneritaDbContext _dbContext;

        public AuthorRepository(GeneritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Author value)
        {
            await _dbContext.Author.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var author = await _dbContext.Author.FindAsync(id);
            if (author is null)
                return false;
            _dbContext.Author.Remove(author);
            return true;
        }

        public async Task<ICollection<Author>> GetAll()
        {
            return await _dbContext.Author.ToListAsync();
        }

        public async Task<Author> GetById(Guid id)
        {
            return await _dbContext.Author.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task<bool> Update(Author value)
        {
            _dbContext.Update(value);
            return Task.FromResult(true);
        }
    }
}
