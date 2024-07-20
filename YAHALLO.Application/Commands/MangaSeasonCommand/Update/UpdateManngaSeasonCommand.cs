using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.MangaSeasonCommand.Update
{
    public class UpdateManngaSeasonCommand: IRequest<ResponseResult<string>>
    {
        public string Id { get; set; }  
        public string Description { get;set; }
        public UpdateManngaSeasonCommand(string id,string description)
        {
            Id=id;  
            Description = description;
        }   
    }
}
