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
    internal class SongCategoryConfig : IEntityTypeConfiguration<Domain.Models.SongCategory>
    {
        public void Configure(EntityTypeBuilder<SongCategory> builder)
        {
            builder.ToTable("SongCategories");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Songs)
                .WithOne(Songs => Songs.Category);
        }
    }
}
