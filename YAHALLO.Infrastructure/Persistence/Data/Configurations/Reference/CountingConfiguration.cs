using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations.Reference
{
    public class CountingConfiguration : IEntityTypeConfiguration<CountingEntitity>
    {
        public void Configure(EntityTypeBuilder<CountingEntitity> builder)
        {
            builder.HasKey(x => x.ParentId);

            builder.ToTable("Counting");
        }
    }
}
