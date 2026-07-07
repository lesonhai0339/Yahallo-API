using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.MangaCommand.MangaDaily;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.FollowCommand.Create
{
    public class CreateFollowMangaCommandHandler : IRequestHandler<CreateFollowMangaCommand, string>
    {
        private readonly IMediator _sender;
        private readonly ICurrentUserService _currentUser;
        private readonly IFollowRepository _followRepository;

        public CreateFollowMangaCommandHandler(
            IMediator sender,
            ICurrentUserService currentUser,
            IFollowRepository followRepository)
        {
            _sender = sender;   
            _currentUser = currentUser;
            _followRepository = followRepository;
        }

        public async Task<string> Handle(CreateFollowMangaCommand request, CancellationToken cancellationToken)
        {
            var following = await _followRepository
                .FindAsync(x => x.UserId == request.UserId && x.MangaId ==  request.MangaId, cancellationToken);

            if (following != null)
                return "Đã follow manga này";

            var followManga = new FollowEntity
            {
                UserId = request.UserId,
                MangaId = request.MangaId,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.UtcNow
            };

            await _sender.Publish(new UpdateMangaDailyNotification { MangaId = request.MangaId, Type = Domain.Enums.MangaDaily.MangaDailyType.Follow }, cancellationToken);


            _followRepository.Add(followManga);
            var result = await _followRepository.UnitOfWork.SaveChangesDroppingDuplicateAnalyticsAsync(cancellationToken);

            return result > 0 ? "Thành công" : "Thát bại";
        }
    }
}
