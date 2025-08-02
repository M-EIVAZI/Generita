﻿using System;
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
    public class SongsRepository : ISongRepository
    {
        private GeneritaDbContext _dbContext;

        public SongsRepository(GeneritaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Songs value)
        {
            await _dbContext.Songs.AddAsync(value);
        }

        public async Task<bool> Delete(Guid id)
        {
            var song = await _dbContext.Songs.FindAsync(id);
            if (song is null)
                return false;
            _dbContext.Songs.Remove(song);
            return true;
        }

        public async Task<ICollection<Songs>> GetAll()
        {
            return await _dbContext.Songs.ToListAsync(); 
        }

        public async Task<Songs> GetById(Guid id)
        {
            return await _dbContext.Songs.FirstOrDefaultAsync(x => x.Id==id);
        }

        public Task<bool> Update(Songs value)
        {
            _dbContext.Songs.Update(value);
            return Task.FromResult(true);
        }
    }
}
