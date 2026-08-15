//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.ReactionEnums;

namespace YAHALLO.Application.Queries.Features.Public.Reaction.Filter
{
    public class FilterReactionQuery : IRequest<PagedResult<ReactionDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

        public string? BlogId { get; set; }
        public string? CommentId { get; set; }
        public string? MangaId { get; set; }
        public string? ChapterId { get; set; }

        /// <summary>Lọc theo người thả cảm xúc. Bỏ trống thì lấy của mọi người.</summary>
        public string? UserId { get; set; }
        public string? UserName { get; set; }

        /// <summary>Chỉ lấy Like hoặc chỉ Dislike. Bỏ trống thì lấy cả hai.</summary>
        public ReactionEnum? Reaction { get; set; }

        public ReactionSortBy SortBy { get; set; }
        public bool ReverseSort { get; set; }
    }
}
