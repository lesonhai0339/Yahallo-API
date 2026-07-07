//AI generated
using MediatR;
using YAHALLO.Application.Commands.MangaCommand.UserMangaDailyRead;
using YAHALLO.Application.Commands.UserCommand.DailyActivity;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ReadingProgressCommand.Upsert
{
    public class UpsertReadingProgressCommandHandler : IRequestHandler<UpsertReadingProgressCommand, string>
    {
        private readonly IMediator _sender;
        private readonly IReadingProgressRepository _progressRepository;
        private readonly ICurrentUserService _currentUser;
        public UpsertReadingProgressCommandHandler(IMediator sender, IReadingProgressRepository progressRepository, ICurrentUserService currentUser)
        {
            _sender = sender;   
            _progressRepository = progressRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(UpsertReadingProgressCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Bạn cần đăng nhập để lưu tiến độ đọc");

            var existing = await _progressRepository.FindAsync(
                x => x.UserId == _currentUser.UserId && x.MangaId == request.MangaId && x.ChapterId == request.ChapterId,
                cancellationToken);

            if (existing is not null)
            {
                existing.LastPage = request.LastPage;
                existing.LastReadAt = DateTime.UtcNow;
                existing.UpdateDate = DateTime.UtcNow;
                existing.IdUserUpdate = _currentUser.UserId;
                _progressRepository.Update(existing);
            }
            else
            {
                var progress = new ReadingProgressEntity
                {
                    UserId = _currentUser.UserId,
                    MangaId = request.MangaId,
                    ChapterId = request.ChapterId,
                    LastPage = request.LastPage,
                    LastReadAt = DateTime.UtcNow,
                    CreateDate = DateTime.UtcNow,
                    IdUserCreate = _currentUser.UserId
                };
                _progressRepository.Add(progress);
            }
            await _sender.Publish(new UserMangaDailyReadNotification { UserId = _currentUser.UserId, MangaId = request.MangaId, ChapterId = request.ChapterId }, cancellationToken);

            await _progressRepository.UnitOfWork.SaveChangesDroppingDuplicateAnalyticsAsync(cancellationToken);
            return "Lưu tiến độ đọc thành công";
        }
    }
}
