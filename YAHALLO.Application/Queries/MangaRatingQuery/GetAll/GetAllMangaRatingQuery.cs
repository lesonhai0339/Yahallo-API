using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.MangaRatingQuery.GetAll
{
    public class GetAllMangaRatingQuery: IRequest<ResponeResult<MangaRatingDto>>
    {
        public GetAllMangaRatingQuery() { }
    }
}
