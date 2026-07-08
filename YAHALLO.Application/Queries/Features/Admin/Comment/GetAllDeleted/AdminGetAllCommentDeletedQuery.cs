using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Comment.GetAllDeleted
{
    public sealed class GetAllCommentDeletedQuery: IRequest<List<AdminCommentDto>>
    { 
    }
}
