//AI generated
using MediatR;

namespace YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetByUser
{
    public class GetReadingProgressByUserQuery : IRequest<List<ReadingProgressDto>>
    {
        public string MangaId { get; set; } = null!;
    }
}
