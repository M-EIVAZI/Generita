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
    public class ParagraphRepository : IParagraphRepository
    {
        private GeneritaDbContext _context;

        public ParagraphRepository(GeneritaDbContext context)
        {
            _context = context;
        }

        public async Task Add(Paragraph value)
        {
            await  _context.Paragraph.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var paragraph=await _context.Paragraph.FirstOrDefaultAsync(x=>x.Id == id);
            if (paragraph is null)
                return false;
            _context.Paragraph.Remove(paragraph);
            return true;

        }

        public async Task<ICollection<Paragraph>> GetAll()
        {
            return await _context.Paragraph.ToListAsync();
        }

        public async Task<Paragraph> GetById(Guid id)
        {
            return await _context.Paragraph.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> Update(Paragraph value)
        {
            _context.Paragraph.Update(value);
            return Task.FromResult(true);
        }
    }
}
