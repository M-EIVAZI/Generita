using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    internal class ViewsConfig : IEntityTypeConfiguration<Views>
    {
        public void Configure(EntityTypeBuilder<Views> builder)
        {
            builder.ToTable("Views");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Views)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Views)
                .HasForeignKey(x => x.BookId);
        }
    }
}
