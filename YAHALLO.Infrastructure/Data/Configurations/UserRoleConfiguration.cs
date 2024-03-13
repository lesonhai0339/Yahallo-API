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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.RoleId);
            builder.HasOne(x=> x.UserEntity)
                .WithMany(y=> y.UserRoleEntities)
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.RoleEntity)
              .WithMany(y => y.UserRoleEntities)
              .HasForeignKey(x => x.RoleId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("UserRole");
        }
    }
}
