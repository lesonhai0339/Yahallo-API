using MediatR;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter.GetAllDeleted
{
    public sealed class GetAllDeletedChapterQueryHandler : IRequestHandler<GetAllDeletedChapterQuery, List<AdminChapterDto>>
    {
        private readonly IChapterRepository _chapterRepository;
        public GetAllDeletedChapterQueryHandler(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
        }
        public async Task<List<AdminChapterDto>> Handle(GetAllDeletedChapterQuery request, CancellationToken cancellationToken)
        {
            var chapters = await _chapterRepository.FindAllSelectAsync(x => x
            .Where(c => !string.IsNullOrEmpty(c.IdUserDelete) && c.DeleteDate.HasValue)
            .Select(t => new AdminChapterDto
            {
                Id = t.Id,
                CreateDate = t.CreateDate,
                Index = t.Index,
                Title = t.Title,    
                MangaId = t.MangaId,
                MangaName = t.MangaEntity == null ? null : t.MangaEntity.Name,
            }),
            cancellationToken,
            true);
            return chapters;
        }
    }
}
