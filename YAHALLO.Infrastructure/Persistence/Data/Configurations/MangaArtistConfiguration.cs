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
    public class MangaArtistConfiguration : IEntityTypeConfiguration<MangaArtistEntity>
    {
        public void Configure(EntityTypeBuilder<MangaArtistEntity> builder)
        {
            builder.HasKey(x => new { x.MangaId, x.ArtistId });

            builder.HasOne(x => x.Manga)
                .WithMany(x => x.ArtistEntities)
                .HasForeignKey(x => x.MangaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Artist)
                .WithMany(x => x.ArtistEntities)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("MangaArtist");
        }
    }
}
