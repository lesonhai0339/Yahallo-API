//AI generated
using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.SubscriptionEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.SubscriptionCommand.Create
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, string>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly ICurrentUserService _currentUser;

        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, ICurrentUserService currentUser)
        {
            _subscriptionRepository = subscriptionRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Bạn cần đăng nhập");

            // Cancel any existing active subscription of the same or lower plan
            var existingActive = await _subscriptionRepository.FindAsync(
                x => x.UserId == _currentUser.UserId && x.Status == SubscriptionStatus.Active,
                cancellationToken);

            if (existingActive is not null)
            {
                existingActive.Status = SubscriptionStatus.Cancelled;
                _subscriptionRepository.Update(existingActive);
            }

            var sub = new SubscriptionEntity
            {
                UserId = _currentUser.UserId,
                Plan = request.Plan,
                Status = SubscriptionStatus.Active,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(request.DurationDays),
                CreateDate = DateTime.Now,
                IdUserCreate = _currentUser.UserId
            };
            _subscriptionRepository.Add(sub);
            await _subscriptionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return $"Đăng ký gói {request.Plan} thành công, có hiệu lực đến {sub.EndDate:dd/MM/yyyy}";
        }
    }
}
