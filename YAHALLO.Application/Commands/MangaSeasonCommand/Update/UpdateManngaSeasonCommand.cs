using MediatR;
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
