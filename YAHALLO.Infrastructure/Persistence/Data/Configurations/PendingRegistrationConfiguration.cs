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

            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email)
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(12);

            builder.Property(x => x.FirstName)
                .IsUnicode(true)
                .HasMaxLength(450);

            builder.Property(x => x.LastName).IsUnicode(true).HasMaxLength(450);

            builder.Property(x => x.CountryId)
              .HasMaxLength(450);
            builder.Property(x => x.UserName)
            .HasMaxLength(450);
            builder.Property(x => x.HashedPassword)
            .HasMaxLength(450);
            builder.Property(x => x.MatchReason)
                .IsUnicode(true)
            .HasMaxLength(2000);

            builder.Property(x => x.ReviewedById)
            .HasMaxLength(45);

            builder.Property(x => x.ReviewNote)
                .IsUnicode (true)   
            .HasMaxLength(2000);


            builder.Property(x => x.MatchReason).IsUnicode(true);
            builder.Property(x => x.ReviewNote).IsUnicode(true);

            builder.ToTable("PendingRegistration");
    }   
    
    }
}
