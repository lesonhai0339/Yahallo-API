//AI generated
using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetByUser
{
    public class GetReadingProgressByUserQueryHandler : IRequestHandler<GetReadingProgressByUserQuery, List<ReadingProgressDto>>
    {
        private readonly IReadingProgressRepository _progressRepository;
        private readonly ICurrentUserService _currentUser;

        public GetReadingProgressByUserQueryHandler(IReadingProgressRepository progressRepository, ICurrentUserService currentUser)
        {
            _progressRepository = progressRepository;
            _currentUser = currentUser;
        }

        public async Task<List<ReadingProgressDto>> Handle(GetReadingProgressByUserQuery request, CancellationToken cancellationToken)
        {
            var progresses = await _progressRepository.FindAllSelectAsync(x => x
                .Where(r => r.UserId == _currentUser.UserId && r.MangaId == request.MangaId)
                .Select(t => new ReadingProgressDto
                {
                    MangaId = t.MangaId,
                    ChapterId = t.ChapterId,
                    ChapterIndex = t.Chapter.Index,
                    ChapterTitle = t.Chapter.Title,
                    LastPage = t.LastPage,
                    LastReadAt = t.LastReadAt,
                    MangaName   = t.Manga.Name,
                    MangaThumbnail = t.Manga.MangaThumbnail
                }),
                cancellationToken);

            return progresses;
        }
    }
}
