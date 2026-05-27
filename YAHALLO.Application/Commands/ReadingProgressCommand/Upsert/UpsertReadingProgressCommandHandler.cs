//AI generated
using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ReadingProgressCommand.Upsert
{
    public class UpsertReadingProgressCommandHandler : IRequestHandler<UpsertReadingProgressCommand, string>
    {
        private readonly IReadingProgressRepository _progressRepository;
        private readonly ICurrentUserService _currentUser;

        public UpsertReadingProgressCommandHandler(IReadingProgressRepository progressRepository, ICurrentUserService currentUser)
        {
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
                existing.LastReadAt = DateTime.Now;
                existing.UpdateDate = DateTime.Now;
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
                    LastReadAt = DateTime.Now,
                    CreateDate = DateTime.Now,
                    IdUserCreate = _currentUser.UserId
                };
                _progressRepository.Add(progress);
            }

            await _progressRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Lưu tiến độ đọc thành công";
        }
    }
}
