//AI generated
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Notification;
using YAHALLO.Domain.Enums.NotificationEnums;

namespace YAHALLO.Application.Queries.Features.Public.Notification.GetByUser
{
    public class GetNotificationsByUserQuery : IRequest<PagedResult<NotificationDto>>
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public NotificationStatus? Status { get; set; }
    }
}
