using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.CommentCommand.Create;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.UserCommand.DailyActivity
{
    public class UpdateDailyActivityNotificationHandler : INotificationHandler<UpdateDailyActivityNotification>
    {
        private readonly ILogger<UpdateDailyActivityNotificationHandler> _logger;

        private readonly IUserDailyActivityRepository _userDailyActivityRepository;
        public UpdateDailyActivityNotificationHandler(ILogger<UpdateDailyActivityNotificationHandler> logger, IUserDailyActivityRepository userDailyActivityRepository)
        {
            _logger = logger;   
            _userDailyActivityRepository = userDailyActivityRepository;
        }   
        public async Task Handle(UpdateDailyActivityNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNullOrEmpty(notification.UserId);
                
                await _userDailyActivityRepository.Increment(notification.UserId, notification.Type, cancellationToken);
            }
            catch (Exception ex) { _logger.LogWarning(ex, "UserDaily increment failed: {Type}", notification.Type); }
        }
    }
}
