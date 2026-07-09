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

            builder.Property(e => e.Title).HasMaxLength(450).IsUnicode(true);
            builder.Property(e => e.Message).IsUnicode(true).HasMaxLength(2000);
            builder.Property(e => e.ReferenceId).HasMaxLength(450);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Notification");
        }
    }
}
