using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace Generita.Infrustructure.Persistance.Configurations
{
    internal class ParagraphConfig : IEntityTypeConfiguration<Paragraph>
    {
        public void Configure(EntityTypeBuilder<Paragraph> builder)
        {
            builder.ToTable("Paragraphs");
            builder.HasKey(p => p.Id);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Paragraphs)
                .HasForeignKey(x => x.BookId);
            builder.HasOne(x => x.Songs)
                .WithMany(x => x.Paragraphs)
                .HasForeignKey(x => x.SongId);
            builder.HasMany(x => x.EntityInstances)
                .WithOne(x => x.Paragraph);
            builder.Property(x => x.MusicSense)
                .HasConversion<string>();
            builder.Property(x=>x.AgeClass)
                .HasConversion<string>();
        }
    }
}
