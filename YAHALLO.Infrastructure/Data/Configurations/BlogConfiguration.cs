using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.HasKey(x=> x.Id);

            builder.HasMany(x => x.DisLikeMetadataByDate)
                .WithOne()
                .HasForeignKey("ParentId")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=> x.LikeMetadataByteDate)
                .WithOne()
                .HasForeignKey("ParentId")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ViewCountMetadataByDate)
                .WithOne()
                .HasForeignKey("ParentId")
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=> x.Medias)
                .WithOne()
                .HasForeignKey("ParentId")
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Blogs");
        }
    }
}
