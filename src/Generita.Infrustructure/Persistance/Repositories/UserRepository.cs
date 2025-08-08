using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private GeneritaDbContext _dbContext;

        public UserRepository(GeneritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User value)
        {
            await _dbContext.Users.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user is null)
                return false;
            _dbContext.Users.Remove(user);
            return true;
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => EF.Functions.Like(x.Email, $"{email}%"));
        }

        public Task<bool> Update(User value)
        {
            _dbContext.Users.Update(value);
            return Task.FromResult(true);
        }
        public async Task<bool> IsExistsByEmail(string email)
        {
            var res = await _dbContext.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower());
            return res;
        }
        public async Task<ICollection<UserBook>> GetByIdWithBooks(Guid id)
        {
            return await _dbContext.UsersBook.Include(x => x.Book).Where(x => x.UserId == id).ToListAsync();
        }
        public async Task AddBookToLibrary(UserBook userbook)
        {
            await _dbContext.UsersBook.AddAsync(userbook);
        }
        public async Task<bool> DeleteBookFromLibrary(Guid bookId, Guid UserId)
        {
            var item = await _dbContext.UsersBook.FirstOrDefaultAsync(x => x.UserId == UserId && x.BookId == bookId);
            if (item == null)
                return false;
            _dbContext.UsersBook.Remove(item);
            return true;
        }
        public async Task<ICollection<BannerBookDto>> GetPopularBooks()
        {
            var popularBooks = await _dbContext.UsersBook
                .Include(x => x.Book)
            .GroupBy(ub => ub.Book) 
            .Select(g => new BannerBookDto
            {
                Book = g.Key,
                UserCount = g.Count()
            })
            .OrderByDescending(g => g.UserCount)
            .Take(10)
            .ToListAsync();
            return popularBooks;
        }
    }
}
