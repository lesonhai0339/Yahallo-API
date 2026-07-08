using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsUnicode(true)
                .HasMaxLength(450)
                .UseCollation("Latin1_General_CI_AI");

            builder.Property(x => x.Description)
                .IsUnicode(true)
                .HasColumnType("nvarchar(max)");


            builder.HasOne(x => x.User)
                .WithMany(x => x.BlogEntities)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict); 


            builder.ToTable("Blogs");
        }
    }
}
