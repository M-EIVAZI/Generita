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

        public  Task<bool> Update(User value)
        {
            _dbContext.Users.Update(value);
            return Task.FromResult(true);
        }
    }
}
