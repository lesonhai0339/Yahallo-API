using MediatR;

namespace YAHALLO.Application.Queries.Features.Admin.Comment.GetAllDeleted
{
    public sealed class AdminGetAllCommentDeletedQuery: IRequest<List<AdminCommentDto>>
    { 
    }
}
