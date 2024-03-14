using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Domain.Entities
{
    public class UserEntity: BaseEntity
    {
        public string? DisplayName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber {  get; set; }
        public bool EmailConfirm { get; set; } = false;
        public bool PhoneConfirmed { get; set; } = false;

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ImageEntity? Avatar { get;set; }
        public virtual UserTokenEntity? UserToken { get; set; }

        public UserStatus Status { get;set; }
        public UserLevel Level { get; set; }

        public virtual ICollection<UserRoleEntity> UserRoleEntities { get; set; }=null!;
        public virtual ICollection<MangaEntity>? MangaEntities { get;set; }
        public virtual ICollection<CommentEntity>? CommentEntities { get; set; }
        public virtual ICollection<CommentEntity>? ReplyComment { get; set; }
        public virtual ICollection<FollowEntity>? FollowEntities { get; set;}
        public virtual ICollection<MangaRatingEntity>? MangaRatingEntities { get; set; }
    }
}
