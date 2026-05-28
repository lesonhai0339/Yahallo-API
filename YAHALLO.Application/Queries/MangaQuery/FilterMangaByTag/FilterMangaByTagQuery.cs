using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.MangaQuery.FilterMangaByTag
{
    public class FilterMangaByTagQuery: IRequest<PagedResult<MangaDto>>
    {
        public FilterMangaByTagQuery() { }  
        public FilterMangaByTagQuery(string tagIds, int pageNumber, int pageSize)
        {
            TagIds = tagIds;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }       
        public string TagIds { get; set;  }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
