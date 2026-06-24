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
    public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettingsEntity>
    {
        public void Configure(EntityTypeBuilder<UserSettingsEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => new { x.Id, x.UserId }).IsUnique();

            builder.HasOne(x => x.User)
                .WithOne(x => x.Settings)
                .HasForeignKey<UserSettingsEntity>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("UserSettings");
        }
    }
}
