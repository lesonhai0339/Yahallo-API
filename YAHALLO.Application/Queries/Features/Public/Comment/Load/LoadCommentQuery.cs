using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Features.Public.Comment.Load
{
    public class LoadCommentQuery: PaginationQuery<CommentDto>
    {
        public string UserId { get; set; } = null!;
        public string? RootCommentId { get; set; }
        public string? CommentId { get; set; }  

        public string? MangaId { get; set;  }
        public string? ChapterId { get; set;  }
        public string? BlogId { get; set;  }
    }
}
