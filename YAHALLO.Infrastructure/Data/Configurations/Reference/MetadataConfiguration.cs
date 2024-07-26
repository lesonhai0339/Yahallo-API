using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Infrastructure.Data.Configurations.Reference
{
    public class MetadataConfiguration : IEntityTypeConfiguration<MetadataEntity>
    {
        public void Configure(EntityTypeBuilder<MetadataEntity> builder)
        {
            builder.HasKey(x=> x.Id);
        }
    }
}
