using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Dtos;
using Generita.Domain.Models;

namespace Generita.Application.Common.Interfaces.Repository
{
    public interface IBookRepository :IGenericRepository<Book>
    {
        Task<ICollection<Book>> SearchBook(string bookName);
        public Task<Dictionary<Guid, int>> GetLikesNumber(IEnumerable<Guid> bookIds);
        Task<ICollection<Book>> GetByPublishedDate(DateOnly dateOnly);
    }
}
