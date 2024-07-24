using System;
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
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public bool EmailConfirm { get; set; } = false;
        public bool PhoneConfirmed { get; set; } = false;

        public string UserName { get; set; } = null!;
        private string _password { get; set; }   
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value && !string.IsNullOrEmpty(_password))
                {
                    OldPasswords.AddNew(value);
                }
                _password = value;
               
            }
        }

        public virtual ImageEntity? Avatar { get; set; }
        public virtual UserTokenEntity? UserToken { get; set; }

        public UserStatus Status { get; set; }
        public UserLevel Level { get; set; }

        public UserOldPasswordEntity OldPasswords { get; set; }

        public virtual ICollection<UserRoleEntity> UserRoleEntities { get; set; }=null!;
        public virtual ICollection<MangaEntity>? MangaEntities { get;set; }
        public virtual ICollection<CommentEntity>? CommentEntities { get; set; }
        public virtual ICollection<CommentEntity>? ReplyComment { get; set; }
        public virtual ICollection<FollowEntity>? FollowEntities { get; set;}
        public virtual ICollection<MangaRatingEntity>? MangaRatingEntities { get; set; }
    }
}
