//AI generated
using MediatR;

namespace YAHALLO.Application.Queries.MangaQuery.GetDetail
{
    public class GetMangaDetailQuery : IRequest<MangaDetailDto>
    {
        public string Id { get; set; } = null!;
    }
}
