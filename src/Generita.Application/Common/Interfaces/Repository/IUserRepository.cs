using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Dtos;
using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task AddBookToLibrary(UserBook userbook);
        Task<bool> DeleteBookFromLibrary(Guid bookId, Guid UserId);
        Task<ICollection<UserBook>> GetByIdWithBooks(Guid id);
        Task<ICollection<BannerBookDto>> GetPopularBooks();
        Task<User> GetUserByEmail(string email);
        Task<bool> IsExistsByEmail(string email);
    }
}
