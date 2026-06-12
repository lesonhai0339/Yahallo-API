using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.MangaQuery.DTOs;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.GetStatus
{
    internal class GetMangaStatusRequestHandler : IRequestHandler<GetMangaStatusRequest, MangaStatusDto>
    {
        private readonly IMangaRepository _mangaRepository;
        public GetMangaStatusRequestHandler(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }

        public async Task<MangaStatusDto> Handle(GetMangaStatusRequest request, CancellationToken cancellationToken)
        {
            var manga = await _mangaRepository.FindSelectAsync(x => x
                .Where(m => m.Id == request.MangaId)
                .Select(t => new MangaStatusDto
                {
                    TotalChapters = t.ChaptersEntities.Count(),
                    TotalViews = t.ViewCount == null ? 0 : t.ViewCount.ViewCount,
                    AverageRating = t.RatingEntities.Select(t => (int?)t.Rating).Average(),
                    TotalFollows = t.FollowEntities.Count()
                }),
                cancellationToken);
            if (manga == null)
                throw new Exception("No data");
            return manga;
        }
    }
}
