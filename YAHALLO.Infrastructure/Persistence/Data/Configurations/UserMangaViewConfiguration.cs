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
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Manga)
                .WithMany()
                .HasForeignKey(e => e.MangaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Index phục vụ dedup theo từng case.
            builder.HasIndex(e => new { e.UserId, e.MangaId, e.ViewedAt });
            builder.HasIndex(e => new { e.VisitorId, e.MangaId, e.ViewedAt });

            builder.ToTable("UserMangaView");
        }
    }
}
