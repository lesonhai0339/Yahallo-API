using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.ChapterCommand.Restore
{
    public class RestoreChapterCommand: IRequest<ResponseResult<string>>
    {
        public string Id { get;set; }
        public RestoreChapterCommand(string id)
        {
            Id = id;
        }
    }
}
