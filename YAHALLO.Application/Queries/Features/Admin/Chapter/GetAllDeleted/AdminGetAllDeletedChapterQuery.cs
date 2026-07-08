using MediatR;
using YAHALLO.Application.Queries.ChapterQuery;

namespace YAHALLO.Application.Queries.Features.Admin.Chapter.GetAllDeleted
{
    public sealed class GetAllDeletedChapterQuery: IRequest<List<AdminChapterDto>>
    {
    }
}
