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
    public class MangaViewConfiguration : IEntityTypeConfiguration<MangaViewEntity>
    {
        public void Configure(EntityTypeBuilder<MangaViewEntity> builder)
        {
            builder.HasKey(x => x.MangaId);

            builder.HasOne(x => x.Manga)
                .WithOne(x => x.MangaView)
                .HasForeignKey<MangaViewEntity>(x => x.MangaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("MangaView");
        }
    }
}
