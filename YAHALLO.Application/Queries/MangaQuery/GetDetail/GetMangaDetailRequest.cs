//AI generated
using MediatR;
using YAHALLO.Application.Queries.MangaQuery.DTOs;

namespace YAHALLO.Application.Queries.MangaQuery.GetDetail
{
    public class GetMangaDetailRequest : IRequest<MangaDetailDto>
    {
        public string Id { get; set; } = null!;
    }
}
