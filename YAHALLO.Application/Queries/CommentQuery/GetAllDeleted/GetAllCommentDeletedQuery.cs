using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.CommentQuery.GetAllDeleted
{
    public class GetAllCommentDeletedQuery: IRequest<ResponseResult<CommentDto>>
    {
        public GetAllCommentDeletedQuery() { }
    }
}
