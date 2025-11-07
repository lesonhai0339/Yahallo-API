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
    public class MangaAuthorConfiguration : IEntityTypeConfiguration<MangaAuthorEntity>
    {
        public void Configure(EntityTypeBuilder<MangaAuthorEntity> builder)
        {
            builder.HasKey(x => new { x.MangaId, x.AuthorId });

            builder.HasOne(x => x.Manga)
                .WithMany(x => x.AuthorEntities)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Author)
                .WithMany(x => x.AuthorEntities)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("MangaAuthor");
        }
    }
}
