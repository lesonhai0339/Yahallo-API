//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.Features.Public.MangaAssociateName.Filter
{
    public class FilterMangaAssociateNameQuery : IRequest<PagedResult<MangaAssociateNameDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

        public string? MangaId { get; set; }
        /// <summary>Tìm theo tên khác — dùng để tra ngược ra truyện từ tên gốc/romaji.</summary>
        public string? Name { get; set; }
        public bool ReverseSort { get; set; }
    }
}
