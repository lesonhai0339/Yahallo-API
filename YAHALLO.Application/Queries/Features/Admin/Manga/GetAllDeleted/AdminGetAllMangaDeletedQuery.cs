using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Manga.GetAllDeleted
{
    public sealed class AdminGetAllMangaDeletedQuery: IRequest<List<AdminMangaDto>>
    {
    }
}
