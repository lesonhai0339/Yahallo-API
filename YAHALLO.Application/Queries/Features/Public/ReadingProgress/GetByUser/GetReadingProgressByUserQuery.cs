//AI generated
using MediatR;
using YAHALLO.Application.Queries.Features.Public.ReadingProgress;

namespace YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetByUser
{
    public class GetReadingProgressByUserQuery : IRequest<List<ReadingProgressDto>>
    {
        public string? UserId { get; set; }
        public string? MangaId { get; set; }
    }
}
