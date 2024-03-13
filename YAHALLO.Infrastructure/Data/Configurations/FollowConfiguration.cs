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
    public class FollowConfiguration : IEntityTypeConfiguration<FollowEntity>
    {
        public void Configure(EntityTypeBuilder<FollowEntity> builder)
        {
            builder.HasKey(x => new { x.UserId, x.MangaId });

            builder.HasOne(x => x.Manga)
                .WithMany(x => x.FollowEntities)
                .HasForeignKey(x => x.MangaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User)
                .WithMany(x => x.FollowEntities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Follow");
        }
    }
}
