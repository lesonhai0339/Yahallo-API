using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Chapter;

namespace YAHALLO.Application.Queries.Features.Public.Chapter.GetImage
{
    public class GetImageQuery: IRequest<List<ChapterImageDto>>
    {
        public string? ChapterId { get; set; }   
    }
}
