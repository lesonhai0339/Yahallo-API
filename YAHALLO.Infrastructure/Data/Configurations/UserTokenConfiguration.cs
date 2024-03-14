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
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserTokenEntity>
    {
        public void Configure(EntityTypeBuilder<UserTokenEntity> builder)
        {
            builder.HasKey(x=> x.Id);

            builder.HasOne(x => x.UserEntity)
                .WithOne(x => x.UserToken)
                .HasForeignKey<UserTokenEntity>(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("UserToken");
        }
    }
}
