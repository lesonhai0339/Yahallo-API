using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class UserMangaDailyReadConfiguration : IEntityTypeConfiguration<UserMangaDailyReadEntity>
    {
        public void Configure(EntityTypeBuilder<UserMangaDailyReadEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).HasColumnType("date");

            builder.HasIndex(x => new { x.UserId, x.ChapterId, x.Date }).IsUnique();
            builder.HasIndex(x => new { x.MangaId, x.Date });

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserMangaDailyReadEntities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Manga)
               .WithMany(x => x.UserMangaDailyReadEntities)
               .HasForeignKey(x => x.MangaId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Chapter)
              .WithMany(x => x.UserMangaDailyReadEntities)
              .HasForeignKey(x => x.ChapterId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("UserMangaDailyRead");
        }
    
    }
}
