using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class EntityConfig : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable("Entity");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Book)
                .WithOne(x => x.Entity)
                .HasForeignKey<Entity>(x => x.BookId);
            builder.HasOne(x => x.Song)
                .WithOne(x => x.Entity)
                .HasForeignKey<Entity>(x => x.SongId);
        }
    }
}
