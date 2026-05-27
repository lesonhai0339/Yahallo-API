//AI generated
using MediatR;

namespace YAHALLO.Application.Queries.ReadingProgressQuery.GetByUser
{
    public class GetReadingProgressByUserQuery : IRequest<List<ReadingProgressDto>>
    {
        /// <summary>If null, returns progress of the currently authenticated user.</summary>
        public string? UserId { get; set; }
        public string? MangaId { get; set; }
    }
}
