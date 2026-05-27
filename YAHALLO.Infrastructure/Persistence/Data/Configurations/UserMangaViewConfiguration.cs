//AI generated
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class UserMangaViewConfiguration : IEntityTypeConfiguration<UserMangaViewEntity>
    {
        public void Configure(EntityTypeBuilder<UserMangaViewEntity> builder)
        {
            builder.HasKey(e => new { e.UserId, e.MangaId });

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Manga)
                .WithMany()
                .HasForeignKey(e => e.MangaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("UserMangaView");
        }
    }
}
