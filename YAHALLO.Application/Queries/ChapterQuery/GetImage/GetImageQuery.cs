using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.ChapterQuery.GetAllImage
{
    public class GetImageQuery: IRequest<List<ChapterImageDto>>
    {
        public string? ChapterId { get; set; }   
    }
}
