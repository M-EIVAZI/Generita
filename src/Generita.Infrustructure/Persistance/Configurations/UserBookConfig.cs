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
    public class UserBookConfig : IEntityTypeConfiguration<UserBook>
    {

        public void Configure(EntityTypeBuilder<UserBook> builder)
        {
            builder.ToTable("UserBook");
            builder.HasKey(t => t.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserBooks)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.UserBooks)
                .HasForeignKey(x => x.BookId);
        }
    }
}
