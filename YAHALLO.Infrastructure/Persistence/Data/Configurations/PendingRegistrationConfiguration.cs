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
    public class PendingRegistrationConfiguration : IEntityTypeConfiguration<PendingRegistrationEntity>
    {
        public void Configure(EntityTypeBuilder<PendingRegistrationEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .IsUnicode(true)
                .HasMaxLength(450);
            builder.Property(x => x.LastName).IsUnicode(true).HasMaxLength(450);

            builder.Property(x => x.MatchReason).IsUnicode(true);
            builder.Property(x => x.ReviewNote).IsUnicode(true);

            builder.ToTable("PendingRegistration");
    }   
    
    }
}
