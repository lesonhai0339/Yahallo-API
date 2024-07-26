using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities.Reference
{
    //This entity is between UserEntity and BlogEntity, using to storage like, dislike, view for specific user to specific blog
    public class ReactionEntity: RelationEntity
    {
        public ReactionEntity() { }
        public ReactionEntity(string userId, UserEntity user, string blogId, BlogEntity blog, bool isLike, bool isDisLike, int visitCount, bool isSaved, float rating, bool isRecommend, bool isFavorite, string note)
        {
            UserId = userId;
            User = user;
            BlogId = blogId;
            Blog = blog;
            IsLike = isLike;
            IsDisLike = isDisLike;
            VisitCount = visitCount;
            IsSaved = isSaved;
            Rating = rating;
            IsRecommend = isRecommend;
            IsFavorite = isFavorite;
            Note = note;
        }

        public required string UserId { get;set; }   
        public required virtual UserEntity User { get; set; }
        public required string BlogId { get; set; }
        public required virtual BlogEntity Blog { get; set; }   
        public bool IsLike { get;set; }
        public bool IsDisLike { get;set; }
        public int VisitCount { get; set; }
        public bool IsSaved { get;set; }    
        public float Rating { get;set; }
        public bool IsRecommend { get; set; }
        public bool IsFavorite { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
