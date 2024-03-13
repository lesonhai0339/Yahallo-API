using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.HasIndex(x => x.Id);

            builder.Property(x=> x.RoleCode)
                .IsUnicode(false);
            builder.Property(x=> x.RoleName)
                .IsUnicode(true)
                .HasMaxLength(450);
            builder.Property(x => x.RoleDescription)
                .IsUnicode(true)
                .HasMaxLength(int.MaxValue);
            builder.ToTable("Roles");
        }
    }
}
