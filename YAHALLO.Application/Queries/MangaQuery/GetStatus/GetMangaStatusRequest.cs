using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.MangaQuery.DTOs;

namespace YAHALLO.Application.Queries.MangaQuery.GetStatus
{
    public class GetMangaStatusRequest: IRequest<MangaStatusDto>
    {
        public string MangaId { get; set; } 
    }
}
