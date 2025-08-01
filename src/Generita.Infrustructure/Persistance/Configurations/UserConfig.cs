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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.firtName)
                .IsRequired()
                .HasMaxLength(30);
                name.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30);
            });
            builder.Property(x=> x.Email)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x=>x.Password)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}
