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
    public class MangaGroupConfiguration : IEntityTypeConfiguration<MangaGroupEntity>
    {
        public void Configure(EntityTypeBuilder<MangaGroupEntity> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name)
                .IsUnicode(true)
                .HasMaxLength(300)
                .UseCollation("Latin1_General_CI_AI");

            builder.Property(x => x.Description)
                .IsUnicode(true)
                .HasMaxLength(2000);

            builder.ToTable("MangaGroup");

        }
    }
}
