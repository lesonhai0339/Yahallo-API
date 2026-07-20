using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Application.Queries.Features.Public.Comment.LoadChild
{
    public class LoadChildCommentQuery: PaginationQuery<CommentDto>
    {
        public string ParentCommentId { get; set; } = null!;
        public string CommentId { get; set; } = null!;
    }
}
