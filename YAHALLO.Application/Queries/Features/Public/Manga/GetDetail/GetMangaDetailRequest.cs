//AI generated
using MediatR;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetDetail
{
    public  sealed class GetMangaDetailRequest : IRequest<MangaDetailDto>
    {
        public string Id { get; set; } = null!;
    }
}
