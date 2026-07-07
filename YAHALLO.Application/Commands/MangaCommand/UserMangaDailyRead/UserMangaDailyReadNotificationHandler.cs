using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaCommand.UserMangaDailyRead
{
    public class UserMangaDailyReadNotificationHandler : INotificationHandler<UserMangaDailyReadNotification>
    {
        private readonly ILogger<UserMangaDailyReadNotificationHandler> _logger;
        private readonly IUserMangaDailyReadRepository _userMangaDailyReadRepository;
        private readonly IUserDailyActivityRepository _userDailyActivityRepository;
        public UserMangaDailyReadNotificationHandler(ILogger<UserMangaDailyReadNotificationHandler> logger, IUserMangaDailyReadRepository userMangaDailyReadRepository, IUserDailyActivityRepository userDailyActivityRepository)
        {
            _logger = logger;   
            _userMangaDailyReadRepository = userMangaDailyReadRepository;
            _userDailyActivityRepository = userDailyActivityRepository;
        }

        public async Task Handle(UserMangaDailyReadNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNullOrEmpty(notification.UserId);
                ArgumentNullException.ThrowIfNullOrEmpty(notification.MangaId);
                ArgumentNullException.ThrowIfNullOrEmpty(notification.ChapterId);

                var today = DateTime.UtcNow.Date; 


                var dailyRead = await _userMangaDailyReadRepository.FindAsync(x =>
                    x.UserId == notification.UserId
                    && x.MangaId == notification.MangaId
                    && x.ChapterId == notification.ChapterId
                    && x.Date == today,
                    cancellationToken);

                if (dailyRead != null)
                    return;

                var daily = new UserMangaDailyReadEntity
                {
                    MangaId = notification.MangaId,
                    ChapterId = notification.ChapterId,
                    UserId = notification.UserId,
                    Date = today
                };
                await _userDailyActivityRepository.Increment(notification.UserId, Domain.Enums.UserDaily.UserDailyType.Read, cancellationToken);
                _userMangaDailyReadRepository.Add(daily);
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex, "UserMangaDaily error");
            }

        }
    }
}
