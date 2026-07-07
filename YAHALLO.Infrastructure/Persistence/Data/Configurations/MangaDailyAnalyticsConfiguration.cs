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
    public class MangaDailyAnalyticsConfiguration : IEntityTypeConfiguration<MangaDailyAnalyticsEntity>
    {
        public void Configure(EntityTypeBuilder<MangaDailyAnalyticsEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).HasColumnType("date");

            builder.HasIndex(x => new { x.MangaId, x.Date })
                .IsUnique();

            builder.HasOne(x => x.Manga)
                .WithMany(x => x.MangaDailyAnalytics)
                .HasForeignKey(x => x.MangaId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.ToTable("MangaDailyAnalytics");
        }
    }
}
