using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author> GetAuthorBooks(Guid id);
        Task<Author> GetAuthorByEmail(string email);
        Task<Author?> GetByAuthorName(string authorName);
        Task<bool> IsExistsByEmail(string email);
    }
}
