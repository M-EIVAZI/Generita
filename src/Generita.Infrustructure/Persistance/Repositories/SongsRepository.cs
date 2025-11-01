using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Common.Enums;
using Generita.Domain.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public async Task<Songs> GetBySenseAndAge(MusicSense musicSense,AgeClasses ageClasses)
        {
            //var authorSong = await _dbContext.Songs
            //.Where(x => x.AgeClasses == ageClasses && x.MusicSense == musicSense && x.Owner == Domain.Enums.OwnerShip.Author)
            //.OrderBy(x => Guid.NewGuid())
            //.FirstOrDefaultAsync();

            //if (authorSong != null)
            //    return authorSong;

            var generatedSong = await _dbContext.Songs
            .Where(x => x.AgeClasses == ageClasses && x.MusicSense == musicSense)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            return generatedSong!;
            //return await _dbContext.Songs.FirstOrDefaultAsync(x=>x.AgeClasses==ageClasses && x.MusicSense==musicSense);
        }
        public async Task<Songs> GetByEntityType(string type)
        {
            return await _dbContext.Songs.FirstOrDefaultAsync(x=>x.EntityType==type);
        }
    }
}
