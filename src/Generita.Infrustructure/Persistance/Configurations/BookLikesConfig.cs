using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    public class BookLikesConfig : IEntityTypeConfiguration<BookLikes>
    {
        public void Configure(EntityTypeBuilder<BookLikes> builder)
        {
            builder.ToTable("BookLikes");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.UserId, x.BookId })
                .IsUnique();
            builder.HasOne(x => x.User)
                .WithMany(x => x.BookLikes)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookLikes)
                .HasForeignKey(x => x.BookId);
        }
    }
}
