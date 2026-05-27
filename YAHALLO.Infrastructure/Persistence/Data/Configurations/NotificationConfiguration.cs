//AI generated
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.UserId);
            builder.HasIndex(e => e.Status);

            builder.Property(e => e.Title).HasMaxLength(256).IsUnicode(true);
            builder.Property(e => e.Message).IsUnicode(true);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Notification");
        }
    }
}
