using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Dtos;
using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Infrustructure.Persistance.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private GeneritaDbContext _db;

        public BookRepository(GeneritaDbContext db)
        {
            _db = db;
        }

        public async Task Add(Book value)
        {
            await _db.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var book = await _db.Book.FindAsync(id);
            if (book is null)
                return false;

            _db.Book.Remove(book);
            return true;
        }

        public async Task<ICollection<Book>> GetAll()
        {
            return await _db.Book.ToListAsync();
        }

        public async Task<Book> GetById(Guid id)
        {
            return await _db.Book.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<ICollection<Book>> SearchBook(string bookName)
        {
            return await _db.Book
                .Where(b => EF.Functions.Like(b.Title.ToLower(), $"%{bookName.ToLower()}%"))
                .ToListAsync();
        }

        public Task<bool> Update(Book value)
        {
            _db.Book.Update(value);
            return Task.FromResult(true);
        }
    }
}
