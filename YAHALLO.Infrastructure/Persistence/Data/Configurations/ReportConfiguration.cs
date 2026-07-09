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
    public class ReportConfiguration : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Title);

            builder.Property(x => x.Title)
                .IsUnicode(true)
                .HasMaxLength(300);

            builder.Property(x => x.Target)
            .HasMaxLength(450);

            builder.Property(x => x.Description)
               .IsUnicode(true)
               .HasMaxLength(2000);

            builder.Property(x => x.IdUserReport)
             .HasMaxLength(450);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Report");
        }
    }
}
