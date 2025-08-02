using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class SongConfig : IEntityTypeConfiguration<Songs>
    {
        public void Configure(EntityTypeBuilder<Songs> builder)
        {
            builder.ToTable("Songs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Owner)
                .IsRequired()
                .HasConversion<string>();
            builder.HasMany(x => x.Books)
                .WithMany(x => x.Songs);
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.FilePath)
                .IsRequired();
        }
    }
}
