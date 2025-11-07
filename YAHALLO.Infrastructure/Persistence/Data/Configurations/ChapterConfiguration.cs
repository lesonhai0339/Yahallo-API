using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<ChapterEntity>
    {
        public void Configure(EntityTypeBuilder<ChapterEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title)
                .IsUnicode(true)
                .HasMaxLength(255);
            builder.Property(x => x.Index)
                .IsUnicode(false);

            builder.HasOne(x => x.MangaEntity)
                .WithMany(x => x.ChaptersEntities)
                .HasForeignKey(x => x.MangaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ViewCount)
                .WithOne(x => x.Chapter)
                .HasForeignKey<CountingEntitity>(x => x.ChapterId);
            builder.ToTable("Chapter");
        }
    }
}
