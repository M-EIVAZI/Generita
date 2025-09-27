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
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Books)
                .WithOne(x => x.Author);
            //builder.OwnsOne(x => x.Name, name =>
            //{
            //    name.Property(x => x.firtName)
            //        .IsRequired()
            //        .HasMaxLength(30);
            //    name.Property(x => x.LastName)
            //    .IsRequired()
            //    .HasMaxLength(30);
            //});
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(70);
            builder.HasIndex(x => x.Email)
                .IsUnique();
            builder.Property(x => x.Password)
                .IsRequired();
        }
    }
}
