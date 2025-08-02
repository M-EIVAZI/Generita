using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Generita.Application.Common.Messaging
{
    public class GeneritaDbContext:DbContext
    {
        public GeneritaDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Entity> Entity { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<SongCategory> SongCategory { get; set; }
        public DbSet<Views> Views { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<Plans> Plans { get; set; }
        //public DbSet<BookSong> BookSong { get; set; }
        //public DbSet<UserPlan> UserPlan { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GeneritaDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
