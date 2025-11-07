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
    public class MangaSeasonConfiguration : IEntityTypeConfiguration<MangaSeasonEntity>
    {
        public void Configure(EntityTypeBuilder<MangaSeasonEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("MangaSeason");
        }
    }
}
