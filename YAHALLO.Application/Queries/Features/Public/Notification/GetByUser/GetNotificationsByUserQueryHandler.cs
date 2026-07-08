//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Application.Queries.Features.Public.Notification;
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

            var query = _notificationRepository.CreateQueryable();
            query = query.Where(x => x.UserId == _currentUser.UserId);

            if (request.Status.HasValue)
                query = query.Where(x => x.Status == request.Status.Value);

            query = query.OrderByDescending(x => x.CreatedAt);

            var paged = await _notificationRepository.FindAllAsync(query, request.PageNo, request.PageSize, cancellationToken);
            return paged.MapToPagedResult(x => _mapper.Map<NotificationDto>(x));
        }
    }
}
