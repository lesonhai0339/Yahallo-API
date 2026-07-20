//AI generated
using AutoMapper;
using MediatR;
using System.Security.Cryptography;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.Comment.Load;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.NotificationEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Notification.GetByUser
{
    public class GetNotificationsByUserQueryHandler : IRequestHandler<GetNotificationsByUserQuery, PagedResult<NotificationDto>>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ICurrentUserService _currentUser;

        public GetNotificationsByUserQueryHandler(
            INotificationRepository notificationRepository, 
            ICurrentUserService currentUser
            )
        {
            _notificationRepository = notificationRepository;
            _currentUser = currentUser;
        }

        public async Task<PagedResult<NotificationDto>> Handle(GetNotificationsByUserQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Bạn cần đăng nhập");

            var result = await _notificationRepository.FeedAsync(_currentUser.UserId, request.PageNo, request.PageSize, cancellationToken);

            return result.MapToPagedResult(x => new NotificationDto
            {
                Id = x.Id,  
                Kind = x.Kind,
                CreateDate = x.CreateDate,
                Seen = x.Seen,               
                Message  = x.Message,
                MentionFrom =  x.MentionFrom,
                BlogId = x.BlogId,
                ChapterId = x.ChapterId,
                CommentId = x.CommentId,
                MangaId  =  x.MangaId,
                RootCommentId = x.RootCommentId,
                TargetId = x.TargetId   
            });
        }
    }
}
