using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaQuery.GetInteraction
{
    public class GetInteractionQuery: IRequest<GetInteractionQueryResult>
    {
        public string MangaId { get; init; } = null!;
    }
    public record GetInteractionQueryResult(string MangaId, string? RatingId, double? Rating, bool Following);
}
