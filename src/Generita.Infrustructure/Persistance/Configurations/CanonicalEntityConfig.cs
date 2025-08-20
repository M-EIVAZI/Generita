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
    public class CanonicalEntityConfig : IEntityTypeConfiguration<CanonicalEntity>
    {
        public void Configure(EntityTypeBuilder<CanonicalEntity> builder)
        {
            builder.ToTable("CanonicalEntity");
            builder.HasKey(x => x.Id);
        }
    }
}
