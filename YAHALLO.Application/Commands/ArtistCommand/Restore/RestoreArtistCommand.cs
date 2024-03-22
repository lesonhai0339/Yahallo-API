using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ArtistCommand.Restore
{
    public class RestoreArtistCommand: IRequest<string>
    {
        public RestoreArtistCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
