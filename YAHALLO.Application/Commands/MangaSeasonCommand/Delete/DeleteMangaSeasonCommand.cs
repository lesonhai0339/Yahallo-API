using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Delete
{
    public class DeleteMangaSeasonCommand: IRequest<ResponseResult<String>>
    {
        public string Id { get;set; }
        public DeleteMangaSeasonCommand(string id)
        {
            Id = id;
        }
    }
}
