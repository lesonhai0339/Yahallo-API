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
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserTokenEntity>
    {
        public void Configure(EntityTypeBuilder<UserTokenEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.RefreshToken)
                .IsUnique();

            builder.Property(x => x.IpAddress)
                .HasMaxLength(200);

            builder.Property(x => x.UserAgent)
                .HasMaxLength(450);  

            builder.Property(x => x.DeviceName)
                .IsUnicode(true)
                .HasMaxLength(200);

            builder.Property(x => x.LoginLocation)
                .IsUnicode (true)
                .HasMaxLength(450); 

            builder.HasOne(x => x.UserEntity)
                .WithMany(x => x.UserTokens)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("UserToken");
        }
    }
}
