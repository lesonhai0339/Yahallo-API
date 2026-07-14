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
    public class MangaConfiguration : IEntityTypeConfiguration<MangaEntity>
    {
        public void Configure(EntityTypeBuilder<MangaEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Description)
                .HasMaxLength(4000);

            builder.Property(x => x.MangaThumbnail)
                .HasMaxLength(2000);

            builder.Property(x => x.MangaBackground)
                .HasMaxLength(2000);


            builder.Property(x => x.Name)
                .IsUnicode(true)
                .HasMaxLength(450)
                .UseCollation("Latin1_General_CI_AI");

            builder.Property(x => x.SeasonName)
               .IsUnicode(true)
               .HasMaxLength(450)
               .UseCollation("Latin1_General_CI_AI");

            builder.HasOne(x => x.MangaGroup)
                .WithMany(x => x.MangaEntities)
                .HasForeignKey(x => x.MangaGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.UserEntity)
                .WithMany(x => x.MangaEntities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.LastChapter)
                .WithMany()
                .HasForeignKey(x => x.LastChapterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Country)
                .WithMany(x => x.MangaEntities)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Manga");
        }
    }
}
