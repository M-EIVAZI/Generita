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
    internal class JobConfig : IEntityTypeConfiguration<Jobs>
    {
        public void Configure(EntityTypeBuilder<Jobs> builder)
        {
            builder.ToTable("Jobs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.JobStatus).HasConversion<string>();
            builder.HasOne(x => x.Author)
                .WithMany(x => x.jobs)
                .HasForeignKey(x => x.AuthorId);
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x => x.BookId);
        }
    }
}
