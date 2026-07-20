//AI generated
using AutoMapper;
using YAHALLO.Application.Common.Mappings;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.NotificationEnums;

namespace YAHALLO.Application.Queries.Features.Public.Notification
{
    public class NotificationDto : IMapFrom<NotificationEntity>
    {
        public string Id { get; set; } = string.Empty;
        public NotificationType Kind { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Seen { get; set; }
        public string? MangaId { get; set; }
        public string?  ChapterId { get; set; }
        public string?  BlogId { get; set; }    
        public string? RootCommentId { get; set; }
        public string? CommentId { get; set; } 
        public string? TargetId { get; set; }
        public string? Message { get; set; }
        public MentionFrom MentionFrom { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NotificationEntity, NotificationDto>();
              
        }
    }
}
