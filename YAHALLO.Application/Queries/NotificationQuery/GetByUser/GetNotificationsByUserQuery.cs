//AI generated
using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.NotificationEnums;

namespace YAHALLO.Application.Queries.NotificationQuery.GetByUser
{
    public class GetNotificationsByUserQuery : IRequest<PagedResult<NotificationDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public NotificationStatus? Status { get; set; }
    }
}
