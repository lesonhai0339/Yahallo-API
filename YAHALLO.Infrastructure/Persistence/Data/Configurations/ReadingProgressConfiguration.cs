//AI generated
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class ReadingProgressConfiguration : IEntityTypeConfiguration<ReadingProgressEntity>
    {
        public void Configure(EntityTypeBuilder<ReadingProgressEntity> builder)
        {
            // Composite key: one record per user × manga × chapter
            builder.HasKey(e => new { e.UserId, e.MangaId, e.ChapterId });

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Manga)
                .WithMany()
                .HasForeignKey(e => e.MangaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Chapter)
                .WithMany()
                .HasForeignKey(e => e.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("ReadingProgress");
        }
    }
}
