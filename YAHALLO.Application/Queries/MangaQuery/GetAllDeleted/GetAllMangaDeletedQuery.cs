using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaQuery.GetAllDeleted
{
    public class GetAllMangaDeletedQuery: IRequest<List<MangaDto>>
    {
        public GetAllMangaDeletedQuery() { }
    }
}
