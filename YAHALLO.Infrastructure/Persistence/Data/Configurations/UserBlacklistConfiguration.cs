using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class UserBlacklistConfiguration : IEntityTypeConfiguration<UserBlacklistEntity>
    {
        public void Configure(EntityTypeBuilder<UserBlacklistEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Reason)
                .IsUnicode(true)
                .HasMaxLength(int.MaxValue);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Blacklist)
                .HasForeignKey<UserBlacklistEntity>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("UserBlacklist");
        }
    }
}
