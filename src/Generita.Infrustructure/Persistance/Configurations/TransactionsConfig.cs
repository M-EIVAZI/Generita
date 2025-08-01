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
    public class TransactionsConfig : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Plan)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.PlanId);
            builder.Property(x => x.States)
                .HasConversion<string>();
        }
    }
}
