using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.FollowQuery.GetAll
{
    public class GetAllFollowMangaQuery: IRequest<List<FollowMangaDto>>
    {
        public GetAllFollowMangaQuery() { }
    }
}
