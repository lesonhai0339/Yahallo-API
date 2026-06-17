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
    public class CountryConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Code).IsUnique();
            builder.HasIndex(x => x.PhoneCode).IsUnique();

            builder.Property(x => x.Name)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(450)
                .UseCollation("Latin1_General_CI_AI");

            builder.Property(x => x.FullName)
              .IsUnicode(true)
              .IsRequired()
              .HasMaxLength(450)
              .UseCollation("Latin1_General_CI_AI");

            builder.ToTable("PhoneCode");
        }
    }
}
