using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Author;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;

namespace YAHALLO.Application.Queries.Features.Public.Author.Filter
{
    public class FilterAuthorQuery: IRequest<PagedResult<AuthorDto>>
    {

        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string? Id { get; set; } = null!;
        public string? Name { get; set; }
    }
}
