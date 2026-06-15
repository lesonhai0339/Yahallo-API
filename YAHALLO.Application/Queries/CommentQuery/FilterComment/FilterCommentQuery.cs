using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.Comment;

namespace YAHALLO.Application.Queries.CommentQuery.FilterComment
{
    public class FilterCommentQuery : IRequest<PagedResult<CommentDto>>
    {
        public int PageNumber { get;set; }
        public int PageSize { get;set; }    
        public string? Id { get; set; }
        public string? UserId { get; set; } 
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }      
        public CommentSortBy? SortBy { get; set;  }
        public bool ReverseSort { get; set; } = false;   
    }
}
