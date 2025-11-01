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
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x=>x.AuthorId);
            builder.HasOne(b => b.BookCategory)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.CategoryId);
            builder.Property(x => x.FilePath)
                .IsRequired();
            builder.Property(x=>x.Access)
                .HasConversion<string>()
                .IsRequired();
            builder.HasMany(x => x.UserBooks)
                .WithOne(x => x.Book);
        }
    }
}
