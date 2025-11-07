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
    public class MangaRatingConfiguration : IEntityTypeConfiguration<MangaRatingEntity>
    {
        public void Configure(EntityTypeBuilder<MangaRatingEntity> builder)
        {
            builder.HasKey(x => new { x.UserId, x.MangaId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.MangaRatingEntities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Manga)
                .WithMany(x => x.RatingEntities)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Rating");
        }
    }
}
