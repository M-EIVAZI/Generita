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
    internal class CanonicalEntityVariantConfig : IEntityTypeConfiguration<CanonicalEntityVariant>
    {
        public void Configure(EntityTypeBuilder<CanonicalEntityVariant> builder)
        {
            builder.ToTable("CanonicalEntityVariant");
            builder.HasKey(x => x.Id);
        }
    }
}
