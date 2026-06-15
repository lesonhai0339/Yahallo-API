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
    public class RatingConfiguration : IEntityTypeConfiguration<RatingEntity>
    {
        public void Configure(EntityTypeBuilder<RatingEntity> builder)
        {
            builder.HasKey(x => x.Id);  

            builder.HasOne(x => x.ToManga)
                .WithMany(x => x.RatingEntities)
                .HasForeignKey(x => x.ToMangaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ToChapter)
                .WithMany(x => x.RatingEntities)
                .HasForeignKey(x => x.ToChapterId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ToUser)
                .WithMany(x => x.RatingEntities)
                .HasForeignKey(x => x.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Rating");
        }
    }
}
