using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Infrastructure.Data.Configurations.Reference
{
    public class UserOldPasswordConfiguration : IEntityTypeConfiguration<UserOldPasswordEntity>
    {
        public void Configure(EntityTypeBuilder<UserOldPasswordEntity> builder)
        {
            builder.HasKey(x=> x.UserId);
            builder.ToTable("OldPassword");
        }
    }
}
