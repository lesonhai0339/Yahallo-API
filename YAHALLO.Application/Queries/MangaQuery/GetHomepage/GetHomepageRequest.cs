using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;

namespace YAHALLO.Application.Queries.MangaQuery.GetHomepage
{
    public class GetHomepageRequest: IRequest<HomePageDto>
    {
        public GetHomepageRequest() { }
    }
}
