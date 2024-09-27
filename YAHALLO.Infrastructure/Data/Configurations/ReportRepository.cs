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
    public class ReportRepository : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            builder.HasKey(x=> x.Id);

            builder.HasOne(x=> x.User)
                .WithMany(x=> x.Reports)
                .HasForeignKey(x=>x.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Report");
        }
    }
}
