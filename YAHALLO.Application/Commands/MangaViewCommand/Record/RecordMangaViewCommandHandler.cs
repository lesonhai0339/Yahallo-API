using MediatR;
using YAHALLO.Application.Common.Exceptions;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaViewCommand.Record
{
    public class RecordMangaViewCommandHandler : IRequestHandler<RecordMangaViewCommand, bool>
    {
        // Cửa sổ dedup: cùng 1 user/khách xem lại manga trong khoảng này chỉ tính 1 view (chống refresh spam).
        private const int DedupWindowMinutes = 2;

        private readonly IViewCountRepository _viewCountRepository;
        private readonly IUserMangaViewRepository _userMangaViewRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IMangaDailyAnalyticsRepository _mangaDailyAnalyticsRepository;

        public RecordMangaViewCommandHandler(
            IViewCountRepository viewCountRepository,
            IUserMangaViewRepository userMangaViewRepository,
            ICurrentUserService currentUser,
            IMangaDailyAnalyticsRepository mangaDailyAnalyticsRepository)
        {
            _viewCountRepository = viewCountRepository;
            _userMangaViewRepository = userMangaViewRepository;
            _currentUser = currentUser;
            _mangaDailyAnalyticsRepository = mangaDailyAnalyticsRepository;   
        }

        public async Task<bool> Handle(RecordMangaViewCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.MangaId))
                throw new BadRequestException("Thiếu MangaId");

            // Case 1: user đã login -> dedup theo UserId.
            // Case 2: khách vãng lai -> dedup theo VisitorId (GUID từ client).
            var userId = _currentUser.UserId;
            var visitorId = string.IsNullOrEmpty(userId) ? request.VisitorId : null;

            // Không định danh được (khách không gửi VisitorId) -> không tính, tránh thổi view.
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(visitorId))
                return false;

            var now = DateTime.UtcNow;
            var since = now.AddMinutes(-DedupWindowMinutes);   // cửa sổ dedup ngắn, chống refresh spam

            // Đã xem manga này trong cửa sổ dedup -> bỏ qua, không tăng đếm.
            var already = !string.IsNullOrEmpty(userId)
                ? await _userMangaViewRepository.FindAsync(
                    x => x.UserId == userId && x.MangaId == request.MangaId && x.ViewedAt >= since, cancellationToken)
                : await _userMangaViewRepository.FindAsync(
                    x => x.VisitorId == visitorId && x.MangaId == request.MangaId && x.ViewedAt >= since, cancellationToken);

            if (already != null)
                return false;

            // Tăng đếm view cho manga (dedup theo manga trong cửa sổ DedupWindowMinutes).
            // Lưu ý: view theo từng chapter cần log dedup riêng (theo chapterId) mới
            // không bị dedup manga chặn — để mở rộng sau nếu cần.
            await IncrementViewAsync(request.MangaId, null, now, cancellationToken);

            // Ghi log để dedup lần sau.
            _userMangaViewRepository.Add(new UserMangaViewEntity
            {
                UserId = userId,
                VisitorId = visitorId,
                MangaId = request.MangaId,
                ViewedAt = now,
                CreateDate = now,
            });

            await _mangaDailyAnalyticsRepository.Increment(request.MangaId, Domain.Enums.MangaDaily.MangaDailyType.View, cancellationToken);

            var result = await _userMangaViewRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        // Get-or-create dòng ViewCount cho manga hoặc chapter rồi +1 (Day/Month/Year/Total).
        private async Task IncrementViewAsync(string? mangaId, string? chapterId, DateTime now, CancellationToken cancellationToken)
        {
            var viewCount = mangaId != null
                ? await _viewCountRepository.FindAsync(x => x.MangaId == mangaId && x.ChapterId == null, cancellationToken)
                : await _viewCountRepository.FindAsync(x => x.ChapterId == chapterId, cancellationToken);

            if (viewCount == null)
            {
                viewCount = new ViewCountEntity
                {
                    MangaId = mangaId,
                    ChapterId = chapterId,
                    LastDateModify = now,
                    LastMonthModify = now,
                    LastYearModify = now,
                };
                viewCount.AddView(now);
                _viewCountRepository.Add(viewCount);
            }
            else
            {
                viewCount.AddView(now);
                _viewCountRepository.Update(viewCount);
            }
        }
    }
}
