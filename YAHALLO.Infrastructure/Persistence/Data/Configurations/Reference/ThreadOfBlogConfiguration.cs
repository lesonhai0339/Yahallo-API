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
    public class ThreadOfBlogConfiguration : IEntityTypeConfiguration<ThreadOfBlogEntity>
    {
        public void Configure(EntityTypeBuilder<ThreadOfBlogEntity> builder)
        {
            builder.HasKey(x => new { x.ThreadId, x.BlogId });

            builder.HasOne(x => x.Thread)
                .WithMany(x => x.ThreadOfBlogEntities)
                .HasForeignKey(x => x.ThreadId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Blog)
                .WithMany(x => x.ThreadOfBlogEntities)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("ThreadOfBlog");
        }
    }
}
