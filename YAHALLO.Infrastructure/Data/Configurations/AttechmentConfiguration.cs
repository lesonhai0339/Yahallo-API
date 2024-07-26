using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Infrastructure.Data.Configurations
{
    public class AttechmentConfiguration : IEntityTypeConfiguration<AttechmentEntity>
    {
        public void Configure(EntityTypeBuilder<AttechmentEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Attechment");
        }
    }
}
