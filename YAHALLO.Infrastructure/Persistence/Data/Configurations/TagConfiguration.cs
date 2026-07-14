//AI generated
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Name);

            builder.Property(e => e.Name)
                .IsUnicode(true)
                .HasMaxLength(450)
                .IsRequired()
                .UseCollation("Latin1_General_CI_AI");

            builder.Property(e => e.Description)
                .IsUnicode(true)
                .HasMaxLength(2000);


            builder.ToTable("Tag");
        }
    }
}
