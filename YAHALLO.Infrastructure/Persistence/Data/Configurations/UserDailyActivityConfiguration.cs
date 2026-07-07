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
    public class UserDailyActivityConfiguration : IEntityTypeConfiguration<UserDailyActivityEntity>
    {
        public void Configure(EntityTypeBuilder<UserDailyActivityEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).HasColumnType("date");

            builder.HasIndex(x => new { x.UserId, x.Date })
                .IsUnique();

            builder.HasOne(x => x.User)
                .WithMany(x => x.DailyActivityEntities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("UserDailyActivity");
        }
    }
}
