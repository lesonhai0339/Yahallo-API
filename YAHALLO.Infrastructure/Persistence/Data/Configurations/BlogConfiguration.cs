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
    public class BlogConfiguration : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ViewCount)
                .WithOne(x => x.Blog)
                .HasForeignKey<CountingEntitity>(x => x.BlogId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Blogs");
        }
    }
}
