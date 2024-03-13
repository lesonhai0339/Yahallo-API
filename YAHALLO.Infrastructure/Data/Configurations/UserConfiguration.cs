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
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email)
                .IsRequired();
            builder.HasIndex(x => x.Email);
            builder.Property(x => x.FirstName)
                .HasMaxLength(200)
                .IsUnicode(true);
            builder.Property(x => x.LastName)
                .HasMaxLength(200)
                .IsUnicode(true);
            builder.Property(x => x.PhoneNumber)
                .IsUnicode(false);

            builder.ToTable("Users");
        }
    }
}
