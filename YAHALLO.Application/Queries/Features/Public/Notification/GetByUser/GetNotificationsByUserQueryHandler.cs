//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Notification.GetByUser
{
    public class GetNotificationsByUserQueryHandler : IRequestHandler<GetNotificationsByUserQuery, PagedResult<NotificationDto>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public GetNotificationsByUserQueryHandler(INotificationRepository notificationRepository, ICurrentUserService currentUser, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<PagedResult<NotificationDto>> Handle(GetNotificationsByUserQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Bạn cần đăng nhập");

            var mention = await LoadMention();
            var noti = await LoadNotification();
        }
        public enum NotificationType
        {
            Mention,
            Notification,
        }
        public enum TargetType
        {
            Manga,
            Chapter,
            Blog
        }
        public class CommentNotification
        {
            public string? MangaId { get; set;  }
            public string? ChapterId { get; set;  }
            public string? BlogId { get; set; }

            public string? RootCommentId { get; set; }  
            public string? CommentId { get; set;  }
        }
        public class OtherNotification
        {
            public  string? TargetId { get; set;  }
        }
        public class NotificationDto
        {
            public string Id { get; set; } = null!;

            public NotificationType NotificationType { get; set;  }
            public TargetType TargetType { get; set; }

            public CommentNotification? CommentNotification { get; set;  }
            public OtherNotification? OtherNotification { get; set;  }
            
        }
        private async Task<List<NotificationDto>> LoadMention()
        {

        }
        private async Task<List<NotificationDto>> LoadNotification()
        {

        }
    }
}
