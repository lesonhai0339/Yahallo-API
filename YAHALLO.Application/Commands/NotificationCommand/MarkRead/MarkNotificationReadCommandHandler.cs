//AI generated
using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Enums.NotificationEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.NotificationCommand.MarkRead
{
    public class MarkNotificationReadCommandHandler : IRequestHandler<MarkNotificationReadCommand, string>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ICurrentUserService _currentUser;

        public MarkNotificationReadCommandHandler(INotificationRepository notificationRepository, ICurrentUserService currentUser)
        {
            _notificationRepository = notificationRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(MarkNotificationReadCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Bạn cần đăng nhập");

            if (!string.IsNullOrEmpty(request.NotificationId))
            {
                var notif = await _notificationRepository.FindAsync(
                    x => x.Id == request.NotificationId && x.UserId == _currentUser.UserId,
                    cancellationToken);
                if (notif is null) throw new NotFoundException("Không tìm thấy thông báo");

                notif.Status = NotificationStatus.Read;
                notif.ReadAt = DateTime.UtcNow;
                _notificationRepository.Update(notif);
            }
            else
            {
                var allUnread = await _notificationRepository.FindAllAsync(
                    x => x.UserId == _currentUser.UserId && x.Status == NotificationStatus.Unread,
                    cancellationToken);

                foreach (var n in allUnread)
                {
                    n.Status = NotificationStatus.Read;
                    n.ReadAt = DateTime.UtcNow;
                    _notificationRepository.Update(n);
                }
            }

            await _notificationRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Đã đánh dấu đã đọc";
        }
    }
}
