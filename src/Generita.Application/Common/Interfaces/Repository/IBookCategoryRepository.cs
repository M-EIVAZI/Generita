using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IBookCategoryRepository : IGenericRepository<BookCategory>
    {
        public Task<ICollection<BookCategory>> GetByName(string name);
        Task<ICollection<BookCategory>> GetByName(string name, DateOnly? fromDate);
    }
}
