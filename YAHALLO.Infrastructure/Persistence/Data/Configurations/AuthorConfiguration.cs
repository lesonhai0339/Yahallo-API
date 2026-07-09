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
    public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Depscription)
    .IsUnicode(true)
    .HasMaxLength(2000);


            builder.Property(x => x.Name)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(255)
                .UseCollation("Latin1_General_CI_AI");


            builder.ToTable("Author");
        }
    }
}
