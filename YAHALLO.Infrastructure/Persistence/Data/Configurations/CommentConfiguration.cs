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
    public class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Message)
                .IsUnicode(true);

            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Entities)
                .HasForeignKey(x => x.Id);
            builder.HasOne(x => x.UserEntity)
                .WithMany(x => x.CommentEntities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.MangaEntity)
                .WithMany(x => x.CommentEntities)
                .HasForeignKey(x => x.MangaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ChapterEntity)
                .WithMany(x => x.CommentEntities)
                .HasForeignKey(x => x.ChapterId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.BlogEntity)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.ViewCount)
                .WithOne(x => x.Comment)
                .HasForeignKey<CountingEntitity>(x => x.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Comment");
        }
    }
}
