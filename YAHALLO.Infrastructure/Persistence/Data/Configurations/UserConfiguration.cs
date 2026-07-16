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
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.CreateDate);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Email)
                .HasMaxLength(450)
                .IsRequired();


            builder.Property(x => x.UserName).HasMaxLength(450);
            builder.Property(x =>  x.Password).HasMaxLength(450);
            builder.Property(x => x.AvatarThumbnail).HasMaxLength(2000);
            builder.Property(x => x.BackgroundThumbnail).HasMaxLength(2000);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(12);

            builder.HasIndex(x => x.CreateDate);

            builder.Property(x => x.FirstName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .UseCollation("Latin1_General_CI_AI");

            builder.Property(x => x.LastName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .UseCollation("Latin1_General_CI_AI");

            builder.Property(x => x.DisplayName)
                .HasMaxLength(200)
                .IsUnicode(true)
                .UseCollation("Latin1_General_CI_AI");

            builder.Property(x => x.PhoneNumber)
                .IsUnicode(false);

            builder.HasOne(x => x.OldPasswords)
               .WithOne(x => x.UserEntity)
               .HasForeignKey<UserOldPasswordEntity>(x => x.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Country)
                .WithMany(x => x.UserEntities)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Users");
        }
    }
}
