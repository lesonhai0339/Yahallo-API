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
    public class ChapterImageConfiguration : IEntityTypeConfiguration<ChapterImageEntity>
    {
        public void Configure(EntityTypeBuilder<ChapterImageEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.ChapterId, x.Index }).IsUnique();

            builder.Property(x => x.Index)
                .HasPrecision(6,2)
                .IsRequired();

            builder.Property(x => x.Url)
                .HasMaxLength(2000);

            builder.Property(x => x.ResizeUrl)
                .HasMaxLength(2000);

            builder.Property(x => x.ContentType)
                .HasMaxLength(450);

            builder.HasOne(x => x.ChapterEntity)
                .WithMany(x => x.ImagesEntities)
                .HasForeignKey(x => x.ChapterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ChapterImage");
        }
    }
}
