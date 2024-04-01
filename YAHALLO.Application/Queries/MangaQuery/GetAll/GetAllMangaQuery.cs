using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaQuery.GetAll
{
    public class GetAllMangaQuery: IRequest<List<MangaDto>>
    {
        public GetAllMangaQuery() { }
    }
}
