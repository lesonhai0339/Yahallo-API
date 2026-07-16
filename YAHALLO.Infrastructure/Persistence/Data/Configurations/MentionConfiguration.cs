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
    public class MentionConfiguration : IEntityTypeConfiguration<MentionEntity>
    {
        public void Configure(EntityTypeBuilder<MentionEntity> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasIndex(x => new { x.UserId, x.Seen });

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Mention");
        }
    }
}
