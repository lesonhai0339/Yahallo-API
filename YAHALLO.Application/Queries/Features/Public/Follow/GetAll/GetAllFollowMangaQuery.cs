using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Follow;

namespace YAHALLO.Application.Queries.Features.Public.Follow.GetAll
{
    public class GetAllFollowMangaQuery: IRequest<List<FollowMangaDto>>
    {
    }
}
