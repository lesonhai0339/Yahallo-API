using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class UnTrustPhoneConfiguration : IEntityTypeConfiguration<UnTrustPhoneEntity>
    {
        public void Configure(EntityTypeBuilder<UnTrustPhoneEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Phone).IsUnique();
            builder.Property(x => x.Phone).HasMaxLength(12);

            builder.Property(x => x.Reason)
.IsUnicode(true)
.HasMaxLength(2000);
            builder.Property(x => x.Source)
   .IsUnicode(true)
   .HasMaxLength(2000);

            builder.ToTable("UnTrustPhone");
        }
    }
}
