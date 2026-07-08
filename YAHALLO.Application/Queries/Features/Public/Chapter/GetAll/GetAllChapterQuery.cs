using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.Features.Public.Chapter.GetAll
{
    public class GetAllChapterQuery: IRequest<ResponseResult<ChapterDto>>
    {
    }
}
