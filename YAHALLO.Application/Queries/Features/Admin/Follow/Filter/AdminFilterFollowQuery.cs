using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.Comment;
using YAHALLO.Domain.Enums.Follow;

namespace YAHALLO.Application.Queries.Features.Admin.Follow.Filter
{
    public class AdminFilterFollowQuery: PaginationQuery<AdminFollowDto>
    {
        public string? MangaId { get; set; }    
        public string? UserId { get; set; }
        public DateTimeOffset? From { get; set; }
        public DateTimeOffset? To { get; set; }
        public FollowSortBy? SortBy { get; set; }
        public bool ReverseSort { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
    }
}
