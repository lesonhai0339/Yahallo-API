using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Domain.Entities
{
    public class ArtistEntity: BaseEntity
    {
        public string Name { get; set; } = null!;
        public CountriesEnum Countries { get; set; }
        public string Depscription { get; set; } = null!;
        public DateTime Birth { get; set; }
        public LifeStatus LifeStatus { get; set; }

        public virtual ICollection<MangaArtistEntity>? ArtistEntities { get; set; }  
    }
}
