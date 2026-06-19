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
    public class BookmarkConfiguration : IEntityTypeConfiguration<BookmarkEntity>
    {
        public void Configure(EntityTypeBuilder<BookmarkEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsUnicode(true)
                .HasMaxLength(450)
                .UseCollation("Latin1_General_CI_AI");

            builder.Property(x => x.Descriptions)
                .IsUnicode(true);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Bookmarks)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.Bookmarks)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Manga)
    .WithMany(x => x.Bookmarks)
    .HasForeignKey(x => x.MangaId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Chapter)
    .WithMany(x => x.Bookmarks)
    .HasForeignKey(x => x.ChapterId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Bookmark");
        }
    }
}
