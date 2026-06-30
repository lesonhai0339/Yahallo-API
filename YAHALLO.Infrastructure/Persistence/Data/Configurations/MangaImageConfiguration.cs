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
    public class MangaImageConfiguration : IEntityTypeConfiguration<ChapterImageEntity>
    {
        public void Configure(EntityTypeBuilder<ChapterImageEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Index)
                .HasPrecision(6,2)
                .IsRequired();

            builder.HasOne(x => x.ChapterEntity)
                .WithMany(x => x.ImagesEntities)
                .HasForeignKey(x => x.ChapterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ChapterImage");
        }
    }
}
