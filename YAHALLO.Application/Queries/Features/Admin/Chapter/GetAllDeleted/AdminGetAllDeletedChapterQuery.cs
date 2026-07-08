using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter.GetAllDeleted
{
    public sealed class AdminGetAllDeletedChapterQuery: IRequest<List<AdminChapterDto>>
    {
    }
}
