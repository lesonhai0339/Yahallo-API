using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ArtistCommand.Delete
{
    public class DeleteArtistCommand: IRequest<string>
    {
        public DeleteArtistCommand(string id)
        {
            Id=  id;
        }
        public string Id { get;set; }
    }
}
