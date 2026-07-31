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
        public DisplayMode DisplayMode { get; set; } = DisplayMode.Visible;
        public MangaType Type { get; set; }
        public CountriesEnum Countries { get; set; }
        public int Season { get; set; }
        public string? MangaThumbnail { get; set; }
        public string? MangaBackground { get;set; }  


        //Newest chapter
        public int? LastChapterIndex { get; set; }  
        public string? LastChapterId { get; set; } 
        public string? LatestChapterTitle { get; set; }
        public DateTime? LastChapterUpdate { get;set; } 

        public string? UserId { get; set; }
        public virtual UserEntity UserEntity { get; set; } = null!;
        public string? MangaGroupId { get; set; }
        public virtual MangaGroupEntity? MangaGroup { get; set; }

        public virtual ViewCountEntity? ViewCount { get; set; }

        public string? CountryId { get; set;  }
        public virtual CountryEntity? Country { get; set;  }

        public virtual ICollection<MangaTagEntity> TagEntities { get; set; } = new List<MangaTagEntity>();
        public virtual ICollection<MangaAssociateNameEntity> AssociateNameEntities {get;set;} = new List<MangaAssociateNameEntity>();   
        public virtual ICollection<MangaArtistEntity> ArtistEntities { get; set; } = new List<MangaArtistEntity>(); 
        public virtual ICollection<MangaAuthorEntity> AuthorEntities { get; set; } = new List<MangaAuthorEntity>();
        public virtual ICollection<ChapterEntity> ChaptersEntities { get; set; } = new List<ChapterEntity>();
        public virtual ICollection<CommentEntity> CommentEntities { get; set; } = new List<CommentEntity>();
        public virtual ICollection<FollowEntity> FollowEntities { get; set; } = new List<FollowEntity>();
        public virtual ICollection<RatingEntity> RatingEntities { get; set; } = new List<RatingEntity>();
        public virtual ICollection<ReactionEntity> Reactions { get; set; } = new List<ReactionEntity>();

        public virtual ICollection<BookmarkEntity> Bookmarks { get; set; } = new List<BookmarkEntity>();

        public virtual ICollection<MangaDailyAnalyticsEntity> MangaDailyAnalytics { get; set; } = new List<MangaDailyAnalyticsEntity>();
        public virtual ICollection<UserMangaDailyReadEntity> UserMangaDailyReadEntities { get; set; } = new List<UserMangaDailyReadEntity>();

    }
}
