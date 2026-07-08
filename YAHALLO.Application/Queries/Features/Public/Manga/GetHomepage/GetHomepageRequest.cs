using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;

namespace YAHALLO.Application.Queries.Features.Public.Manga.GetHomepage
{
    public class GetHomepageRequest: IRequest<HomePageDto>
    {
    }
}
