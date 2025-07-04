﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.FollowQuery.Filter
{
    public class FilterFollowMangaQuery: IRequest<PagedResult<FollowMangaDto>>
    {
        public int PageNumber { get;set; }
        public int PageSize { get;set; }
        public string? UserId { get;set; }
        public string? UserName { get; set; }
        public string? MangaId { get;set; }
        public string? MangaName { get ; set; } 
    }
}
