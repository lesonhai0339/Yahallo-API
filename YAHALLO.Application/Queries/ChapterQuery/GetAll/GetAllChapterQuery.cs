﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.ChapterQuery.GetAll
{
    public class GetAllChapterQuery: IRequest<ResponseResult<ChapterDto>>
    {
        public GetAllChapterQuery() { }
    }
}
