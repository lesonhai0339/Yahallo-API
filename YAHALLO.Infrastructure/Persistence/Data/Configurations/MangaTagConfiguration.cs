//AI generated
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class MangaTagConfiguration : IEntityTypeConfiguration<MangaTagEntity>
    {
        public void Configure(EntityTypeBuilder<MangaTagEntity> builder)
        {
            builder.HasKey(e => new { e.MangaId, e.TagId });

            builder.HasOne(e => e.Manga)
                .WithMany()
                .HasForeignKey(e => e.MangaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Tag)
                .WithMany(t => t.MangaTagEntities)
                .HasForeignKey(e => e.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("MangaTag");
        }
    }
}
