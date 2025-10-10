using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Http.Logging;

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

        public async Task<ICollection<BookCategory>> GetByName(string name)
        {
            return await _dbContext.BookCategory
                .Include(x => x.Books)
                .Where(x => EF.Functions.Like(x.CategoryName, $"%{name}%"))
                .ToListAsync();
        }
        public async Task<ICollection<BookCategory>> GetByName(string name, DateOnly? fromDate)
        {
            var query = _dbContext.BookCategory.AsQueryable();

            if (fromDate is not null)
            {
                query = query.Include(c => c.Books
                    .Where(b => b.PublishedDate >= fromDate));
            }
            else
            {
                query = query.Include(c => c.Books);
            }

            return await query
                .Where(c => EF.Functions.Like(c.CategoryName, $"%{name}%"))
                .ToListAsync();
        }



    }
}
