using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.ReactionEnums;

namespace YAHALLO.Domain.Entities.Reference
{
    //This entity is between UserEntity and BlogEntity, using to storage like, dislike, view for specific user to specific blog
    public class ReactionEntity: BaseEntity
    {
        // The person reaction
        public required string UserId { get;set; }   
        public required virtual UserEntity User { get; set; }
        public ReactionEnum Reaction { get;set; }

        public string? BlogId { get; set; }
        public virtual BlogEntity? Blog { get; set; }

        public string? CommentId { get; set; }  
        public virtual CommentEntity? Comment { get; set; } 

        public string?  MangaId { get; set; }
        public virtual MangaEntity? Manga { get; set; } 

        public string? ChapterId{ get; set; }   
        public virtual ChapterEntity? Chapter { get; set; }
    }
}