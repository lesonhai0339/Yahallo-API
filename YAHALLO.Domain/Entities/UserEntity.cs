using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity() { }
        public UserEntity(
            string? displayname,
            string? firstname,
            string? lastname,
            string email,
            string? phone,
            string username,
            string password)
        {
            DisplayName = displayname;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PhoneNumber = phone;
            UserName = username;
            Password = password;
        }
        public string? DisplayName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public bool EmailConfirm { get; set; } = false;
        public bool PhoneConfirmed { get; set; } = false;

        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public virtual ImageEntity? Avatar { get; set; }
        public virtual UserTokenEntity? UserToken { get; set; }

        public UserStatus Status { get; set; }
        public UserLevel Level { get; set; }

        public virtual UserOldPasswordEntity? OldPasswords { get; set; }

        public virtual ICollection<UserRoleEntity> UserRoleEntities { get; set; }=null!;
        public virtual ICollection<MangaEntity>? MangaEntities { get;set; }
        public virtual ICollection<CommentEntity>? CommentEntities { get; set; }
        public virtual ICollection<CommentEntity>? ReplyComment { get; set; }
        public virtual ICollection<FollowEntity>? FollowEntities { get; set;}
        public virtual ICollection<MangaRatingEntity>? MangaRatingEntities { get; set; }
        public virtual ICollection<ReactionEntity>? Reactions { get; set; }
        public virtual ICollection<ReportEntity>? Reports { get; set; }

        public UserEntity? ConvertFromString(string classname)
        {
            var local = typeof(UserEntity);
            var type = Type.GetType(string.Format($"{local.Namespace}.{0}", classname);
            return (UserEntity?)Activator.CreateInstance(type);
        }
    }
}
