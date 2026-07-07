using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.MangaCommand.MangaDaily;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.FollowCommand.Delete
{
    public class DeleteFollowMangaCommandHandler : IRequestHandler<DeleteFollowMangaCommand, string>
    {
        private readonly IMediator _sender;
        private readonly IFollowRepository _followRepository;
        private readonly ICurrentUserService _currentUser;

        public DeleteFollowMangaCommandHandler(IMediator sender, IFollowRepository followRepository, ICurrentUserService currentUser, IMangaDailyAnalyticsRepository mangaDailyAnalyticsRepository)
        {
            _sender = sender;   
            _followRepository = followRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(DeleteFollowMangaCommand request, CancellationToken cancellationToken)
        {
            var checkFollowExist = await _followRepository
                .FindAsync(x => x.UserId == request.UserId && x.MangaId == request.MangaId
                & string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkFollowExist == null)
                throw new NotFoundException($"Không tìm thấy bản ghi nào với User Id: {request.UserId} và Manga Id: {request.MangaId}");

            await _sender.Publish(new UpdateMangaDailyNotification { MangaId = request.MangaId, Type = Domain.Enums.MangaDaily.MangaDailyType.Follow, IsDelete = true }, cancellationToken);


            _followRepository.Remove(checkFollowExist);
            var result = await _followRepository.UnitOfWork.SaveChangesDroppingDuplicateAnalyticsAsync(cancellationToken);


            return result > 0 ? "Thành công" : "Thất bại";
        }
    }
}
