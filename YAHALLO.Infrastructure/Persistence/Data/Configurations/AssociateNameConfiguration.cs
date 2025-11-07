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
    public class AssociateNameConfiguration : IEntityTypeConfiguration<MangaAssociateNameEntity>
    {
        public void Configure(EntityTypeBuilder<MangaAssociateNameEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsUnicode(true)
                .HasMaxLength(255);


            builder.HasOne(x => x.Manga)
                .WithMany(x => x.AssociateNameEntities)
                .HasForeignKey(x => x.MangaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("AssociateName");
        }
    }
}
