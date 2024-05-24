using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.ChapterQuery.GetAll
{
<<<<<<< HEAD
    public class GetAllChapterQuery: IRequest<List<ChapterDto>>
=======
    public class GetAllChapterQuery: IRequest<ResponeResult<ChapterDto>>
>>>>>>> master
    {
        public GetAllChapterQuery() { }
    }
}
