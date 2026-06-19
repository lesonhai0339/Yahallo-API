using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations.Reference
{
    public class ReactionConfiguration : IEntityTypeConfiguration<ReactionEntity>
    {
        public void Configure(EntityTypeBuilder<ReactionEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reactions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.Reactions)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Comment)
    .WithMany(x => x.Reactions)
    .HasForeignKey(x => x.CommentId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Manga)
    .WithMany(x => x.Reactions)
    .HasForeignKey(x => x.MangaId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Chapter)
    .WithMany(x => x.Reactions)
    .HasForeignKey(x => x.ChapterId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Reaction");
        }
    }
}
