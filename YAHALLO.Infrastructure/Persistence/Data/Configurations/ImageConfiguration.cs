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
    public class ImageConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Index)
                .IsUnicode(false)
                .IsRequired();
            builder.HasOne(x => x.UserEntity)
                .WithOne(x => x.Avatar)
                .HasForeignKey<ImageEntity>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.MangaEntity)
               .WithOne(x => x.Thumbnail)
               .HasForeignKey<ImageEntity>(x => x.MangaId)
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ChapterEntity)
                .WithMany(x => x.ImagesEntities)
                .HasForeignKey(x => x.ChapterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Image");
        }
    }
}
