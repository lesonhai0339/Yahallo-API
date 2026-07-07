using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.Hubs.UpdateLastActive
{
    public class UpdateLastActiveCommandHandler : INotificationHandler<UpdateLastActiveCommand>
    {
        private readonly IUserDailyActivityRepository _userDailyActivityRepository;
        public UpdateLastActiveCommandHandler(IUserDailyActivityRepository userDailyActivityRepository)
        {
            _userDailyActivityRepository = userDailyActivityRepository;
        }

        public async Task Handle(UpdateLastActiveCommand request, CancellationToken cancellationToken)
        {
            await _userDailyActivityRepository.Increment(request.UserId, Domain.Enums.UserDaily.UserDailyType.Activity, cancellationToken);
            await _userDailyActivityRepository.UnitOfWork.SaveChangesDroppingDuplicateAnalyticsAsync(cancellationToken);
        }
    }
}
