using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Domain.Entities
{
    public class CountryEntity: BaseEntity
    {
        public int Code { get; set;  }
        public int PhoneCode { get; set; }
        public string Name { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public virtual ICollection<MangaEntity> MangaEntities { get; set; } = new List<MangaEntity>();
        public virtual ICollection<UserEntity> UserEntities { get; set;  } = new List<UserEntity>();        
    }
}
