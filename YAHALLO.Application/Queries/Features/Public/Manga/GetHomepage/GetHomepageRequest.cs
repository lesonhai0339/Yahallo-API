using MediatR;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetHomepage
{
    public class GetHomepageRequest: IRequest<HomePageDto>
    {
    }
}
