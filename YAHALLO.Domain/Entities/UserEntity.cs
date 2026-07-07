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
            string password,
            string? avatarThumbnail,
            string? background)
        {
            DisplayName = displayname;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PhoneNumber = phone;
            UserName = username;
            Password = password;
            AvatarThumbnail = avatarThumbnail ?? string.Empty;
            BackgroundThumbnail = background;
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
        public UserStatus Status { get; set; }
        public UserLevel Level { get; set; }
        public DateTime LastActiveTime { get; set; } = DateTime.UtcNow;
        public string? AvatarThumbnail { get; set; } = string.Empty; 
        public string? BackgroundThumbnail { get; set; } = string.Empty;    


        public string? CountryId { get; set; }
        public virtual CountryEntity? Country { get; set; }  


        public virtual UserBlacklistEntity? Blacklist { get; set;  }

        public virtual UserOldPasswordEntity? OldPasswords { get; set; }

        public virtual UserSettingsEntity? Settings { get; set; }

        public virtual ICollection<UserTokenEntity> UserTokens { get; set; } = new List<UserTokenEntity>();

        public virtual ICollection<UserRoleEntity> UserRoleEntities { get; set; } = new List<UserRoleEntity>();
        public virtual ICollection<MangaEntity> MangaEntities { get;set; } = new List<MangaEntity> ();
        public virtual ICollection<CommentEntity> CommentEntities { get; set; } = new List<CommentEntity>();
        public virtual ICollection<CommentEntity> ReplyComment { get; set; } = new List<CommentEntity>();  
        public virtual ICollection<FollowEntity> FollowEntities { get; set;} = new List<FollowEntity> ();
        public virtual ICollection<ReactionEntity> Reactions { get; set; } = new List<ReactionEntity>   ();
        public virtual ICollection<ReportEntity> Reports { get; set; } = new List<ReportEntity>();
        public virtual ICollection<RatingEntity> RatingEntities { get; set; } = new List<RatingEntity>();
        public virtual ICollection<BookmarkEntity> Bookmarks { get; set; } = new List<BookmarkEntity>();
        public virtual ICollection<UserDailyActivityEntity> DailyActivityEntities { get; set; } = new List<UserDailyActivityEntity>();
        public virtual ICollection<UserMangaDailyReadEntity> UserMangaDailyReadEntities { get; set; } = new List<UserMangaDailyReadEntity>();

        public UserEntity? ConvertFromString(string classname)
        {
            var local = typeof(UserEntity);
            var type = Type.GetType(string.Format($"{local.Namespace}.{0}", classname));
            return (UserEntity?)Activator.CreateInstance(type!);
        }
    }
}
