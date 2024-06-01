using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Restore
{
    public class RestoreMangaSeasonCommand: IRequest<ResponseResult<string>>
    {
        public string Id { get; set; }  
        public RestoreMangaSeasonCommand(string id)
        {
            Id = id;
        }   
    }
}
