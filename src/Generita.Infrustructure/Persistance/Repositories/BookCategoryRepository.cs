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
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private GeneritaDbContext _dbContext;

        public BookCategoryRepository(GeneritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(BookCategory value)
        {
            await _dbContext.BookCategory.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _dbContext.BookCategory.FindAsync(id);
            if (category is null)
                return false;
            _dbContext.BookCategory.Remove(category);
            return true;
        }

        public async Task<ICollection<BookCategory>> GetAll()
        {
            return await _dbContext.BookCategory.ToListAsync();
        }

        public async Task<BookCategory> GetById(Guid id) => await _dbContext.BookCategory.FirstOrDefaultAsync(c => c.Id == id);

        public Task<bool> Update(BookCategory value)
        {
            _dbContext.BookCategory.Update(value);
            return Task.FromResult(true);
        }
    }
}
