using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Dtos;
using Generita.Domain.Common.Enums;
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

        public async Task<Dictionary<Guid, int>> GetLikesNumber(IEnumerable<Guid> bookIds)
        {
            return await _db.BookLikes
                .Where(bl => bookIds.Contains(bl.BookId))
                .GroupBy(bl => bl.BookId)
                .Select(g => new { BookId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.BookId, x => x.Count);
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
        public async Task<ICollection<Book>> GetByPublishedDate(DateOnly dateOnly)
        {
            return await _db.Book
                .Include(b => b.Author)
                .Where(x => x.PublishedDate == dateOnly)
                .ToListAsync();
        }
        public async Task<ICollection<Book>> GetNewestBooks()
        {
            return await _db.Book.Include(b => b.Author).Include(b => b.BookCategory).OrderByDescending(x=>x.PublishedDate).Take(10).ToListAsync();
        }
        public async Task<ICollection<Book>> GetSubscriptionOnly()
        {
            return await _db.Book.Include(x => x.Author).Include(x => x.BookCategory).Where(x => x.Access == BookAccess.Subscription).ToListAsync();
        }
        public async Task<ICollection<Book>> GetFreeOnly()
        {
            return await _db.Book.Include(x => x.Author).Include(x => x.BookCategory).Where(x => x.Access == BookAccess.Free).ToListAsync();
        }
        public async Task<ICollection<Book>> GetAuthorBooks(Guid id)
        {
            return await _db.Book.Where(x => x.AuthorId == id).ToListAsync();
        }
    }
}
