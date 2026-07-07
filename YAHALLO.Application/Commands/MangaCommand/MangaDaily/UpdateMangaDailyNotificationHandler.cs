using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaCommand.MangaDaily
{
    public class UpdateMangaDailyNotificationHandler : INotificationHandler<UpdateMangaDailyNotification>
    {
        private readonly ILogger<UpdateMangaDailyNotificationHandler> _logger;
        private readonly IMangaDailyAnalyticsRepository _analyticsRepository;
        public UpdateMangaDailyNotificationHandler( ILogger<UpdateMangaDailyNotificationHandler> logger ,IMangaDailyAnalyticsRepository analyticsRepository)
        {
            _logger = logger;   
            _analyticsRepository = analyticsRepository;
        }   
        public async Task Handle(UpdateMangaDailyNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNullOrEmpty(notification.MangaId);

                if (notification.IsDelete && notification.Type == Domain.Enums.MangaDaily.MangaDailyType.Follow)
                    await _analyticsRepository.DecrementFollower(notification.MangaId, cancellationToken);
                else
                    await _analyticsRepository.Increment(notification.MangaId, notification.Type, cancellationToken);

            }
            catch (Exception ex) { _logger.LogWarning(ex, "MangaDaily increment failed: {Type}", notification.Type); }

        }
    }
}
