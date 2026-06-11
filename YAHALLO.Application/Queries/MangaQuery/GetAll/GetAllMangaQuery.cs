using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.MangaQuery.DTOs;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.MangaQuery.GetAll
{
    public class GetAllMangaQuery: IRequest<ResponseResult<MangaDto>>
    {
        public GetAllMangaQuery() { }
    }
}
