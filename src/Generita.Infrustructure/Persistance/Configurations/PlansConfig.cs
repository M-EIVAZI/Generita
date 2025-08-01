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
    public class PlansConfig : IEntityTypeConfiguration<Plans>
    {
        public void Configure(EntityTypeBuilder<Plans> builder)
        {
            builder.ToTable("Plans");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Transactions)
                .WithOne(x => x.Plan);

        }
    }
}
