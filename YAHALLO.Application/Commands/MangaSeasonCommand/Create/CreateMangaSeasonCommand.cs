using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Create
{
    public class CreateMangaSeasonCommand: IRequest<ResponseResult<string>>
    {
        public double Season { get; set; }
        public string Description { get; set; }
        public CreateMangaSeasonCommand(
            double season, string description)
        {
            Season = season;    
            Description = description;  
        }
    }
}
