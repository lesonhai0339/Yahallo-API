//AI generated
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pipelines.Sockets.Unofficial.Arenas;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.NotificationEnums;
using YAHALLO.Domain.Repositories;
using YAHALLO.Infrastructure.Data;
using static YAHALLO.Application.Queries.Features.Public.Notification.GetByUser.GetNotificationsByUserQueryHandler;

namespace YAHALLO.Infrastructure.Persistence.Repositories
{
    public class NotificationRepository : RepositoryBase<NotificationEntity, NotificationEntity, ApplicationDbContext>, INotificationRepository
    {
        private readonly  IMentionRepository _mentionRepository;    
        public NotificationRepository(ApplicationDbContext dbContext, IMapper mapper, IMentionRepository mentionRepository) : base(dbContext, mapper) 
        {
            _mentionRepository = mentionRepository;
        }
        public async Task<IPagedResult<NotifRow>> FeedAsync(string uid, int pageNo, int PageSize, CancellationToken cancellationToken)
        {
            var mentionQuery = _mentionRepository.CreateQueryable()
                .Where(x => x.UserId == uid && !x.Seen)
                .Select(m => new NotifRow
                {
                    Id = m.Id,
                    Kind = NotificationType.Mention,
                    CreateDate = m.CreateDate,
                    Seen = m.Seen,
                    MangaId = m.MangaId,
                    ChapterId = m.ChapterId,
                    BlogId = m.BlogId,
                    RootCommentId = m.RootCommentId,
                    CommentId = m.CommentId,
                    MentionFrom = m.MentionFrom,
                    TargetId = null,
                    Message = "Một ai đó đã đề cập đến bạn"
                });

            var notificationQuery = CreateQueryable()
                .Where(x => x.UserId == uid && x.Status == NotificationStatus.Unread)
                .Select(n => new NotifRow
                {
                    Id = n.Id,
                    Kind = n.Type,
                    CreateDate = n.CreateDate,
                    Seen = n.Status == NotificationStatus.Read,
                    TargetId = n.ReferenceId,
                    Message = n.Message,
                    MangaId = null,                        
                    ChapterId = null,                     
                    BlogId = null,                         
                    RootCommentId = null,               
                    CommentId = null,                      
                    MentionFrom = MentionFrom.None,      
                });

            var union = mentionQuery.Concat(notificationQuery).OrderByDescending(x => x.CreateDate).ThenBy(x => x.Id);
            return await PagedList<NotifRow>.CreateAsync(
                union,
                pageNo,
                PageSize,
                cancellationToken);
        } 
    }
}
