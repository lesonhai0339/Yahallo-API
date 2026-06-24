//AI generated
using MediatR;

namespace YAHALLO.Application.Queries.ReadingProgressQuery.GetByUser
{
    public class GetReadingProgressByUserQuery : IRequest<List<ReadingProgressDto>>
    {
        public string? UserId { get; set; }
        public string? MangaId { get; set; }
    }
}
