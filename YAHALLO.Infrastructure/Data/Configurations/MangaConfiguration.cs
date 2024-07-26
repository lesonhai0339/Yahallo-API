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
    public class MangaConfiguration : IEntityTypeConfiguration<MangaEntity>
    {
        public void Configure(EntityTypeBuilder<MangaEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(x=> x.Id);
            builder.Property(x => x.Name)
                .IsUnicode(true)
                .HasMaxLength(256);
            builder.Property(x => x.Description)
                .IsUnicode(true);

            builder.HasOne(x => x.MangaSeasonEntity)
                .WithMany(x => x.MangaEntities)
                .HasForeignKey(x => x.MangaSeasonId);
            builder.HasOne(x=> x.UserEntity)
                .WithMany(x=> x.MangaEntities)
                .HasForeignKey(x => x.UserId);
            builder.ToTable("Manga");
        }
    }
}
