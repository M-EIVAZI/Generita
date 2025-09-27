using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Generita.Infrustructure.Persistance.Configurations
{
    internal class EntityInstancesConfig : IEntityTypeConfiguration<EntityInstances>
    {
        public void Configure(EntityTypeBuilder<EntityInstances> builder)
        {
            builder.ToTable("EntityInstances");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Paragraph)
                .WithMany(x => x.EntityInstances)
                .HasForeignKey(x => x.ParagraphId);
            builder.HasOne(x => x.Entity)
                .WithMany(x => x.Instances)
                .HasForeignKey(x => x.EntityId);
        }
    }
}
