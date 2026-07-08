using MediatR;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.Comment;

namespace YAHALLO.Application.Queries.Features.Public.Comment.FilterComment
{
    public class FilterCommentQuery : IRequest<PagedResult<CommentDto>>
    {
        public int PageNo { get;set; }
        public int PageSize { get;set; }    
        public string? Id { get; set; }
        public string? UserId { get; set; } 
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }    
        public string? ParentId { get; set; }   
        public CommentSortBy? SortBy { get; set;  }
        public bool ReverseSort { get; set; } = false;   
    }
}
