using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.FollowQuery.GetAllDeleted
{
    public class GetAllDeletedFollowMangaQuery: IRequest<List<FollowMangaDto>>
    {
        public GetAllDeletedFollowMangaQuery() { }  
    }
}
