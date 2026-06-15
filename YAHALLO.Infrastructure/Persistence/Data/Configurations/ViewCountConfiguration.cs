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
    public class ViewCountConfiguration : IEntityTypeConfiguration<ViewCountEntity>
    {
        public void Configure(EntityTypeBuilder<ViewCountEntity> builder)
        {
            
            builder.HasKey(x => x.Id);  

            builder.HasOne(x => x.Manga)
                .WithOne(x => x.ViewCount)
                .HasForeignKey<ViewCountEntity>(x => x.MangaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Chapter)
                .WithOne(x => x.ViewCount)
                .HasForeignKey<ViewCountEntity>(x => x.ChapterId)   
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Comment)
                .WithOne(x => x.ViewCount)
                .HasForeignKey<ViewCountEntity>(x => x.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Blog)
               .WithOne(x => x.ViewCount)
               .HasForeignKey<ViewCountEntity>(x => x.BlogId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ViewCount");
        }
    }
}
