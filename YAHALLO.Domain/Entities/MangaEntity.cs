using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Domain.Entities
{
    [Serializable]
    public class MangaEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public MangaLevel Level { get; set; }
        public MangaStatus Status { get; set; }
        public MangaType Type { get; set; }
        public CountriesEnum Countries { get; set; }
        public int Season { get; set; }

        public string? MangaSeasonId { get; set; }
        public virtual MangaSeasonEntity MangaSeasonEntity { get; set; } = null!;
        public string? UserId { get; set; }
        public virtual UserEntity UserEntity { get; set; } = null!;
        public virtual MangaViewEntity? MangaView { get; set; }
        public virtual ImageEntity? Thumbnail { get; set; }
        public virtual CountingEntitity? ViewCount { get; set; }

        public virtual ICollection<MangaAssociateNameEntity>? AssociateNameEntities {get;set;}
        public virtual ICollection<MangaArtistEntity> ArtistEntities { get; set; } = null!;
        public virtual ICollection<MangaAuthorEntity> AuthorEntities { get; set; } = null!;
        public virtual ICollection<ChapterEntity>? ChaptersEntities { get; set; }
        public virtual ICollection<CommentEntity>? CommentEntities { get; set; }
        public virtual ICollection<FollowEntity>? FollowEntities { get; set; }  
        public virtual ICollection<MangaRatingEntity>? RatingEntities { get; set;}
    }
}
