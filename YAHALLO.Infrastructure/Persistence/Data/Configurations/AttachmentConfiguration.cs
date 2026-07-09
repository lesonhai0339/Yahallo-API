using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Infrastructure.Persistence.Data.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<AttachmentEntity>
    {
        public void Configure(EntityTypeBuilder<AttachmentEntity> builder)
        {
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Description)
                .IsUnicode()
                .HasMaxLength(2000);

            builder.Property(x => x.Title)
                .IsUnicode(true)
                .HasMaxLength(2000);

            builder.Property(x => x.Url1)
              .HasMaxLength(450);
            builder.Property(x => x.Url2)
              .HasMaxLength(450);
            builder.Property(x => x.Url3)
              .HasMaxLength(450);

            builder.HasOne(x => x.Comment)
                .WithMany(x => x.Attechments)
                .HasForeignKey(x => x.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.Attechments)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Attachment");
        }
    }
}
