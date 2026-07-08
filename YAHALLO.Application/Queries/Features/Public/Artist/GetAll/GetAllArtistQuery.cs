using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Artist;

namespace YAHALLO.Application.Queries.Features.Public.Artist.GetAll
{
    public class GetAllArtistQuery: IRequest<List<ArtistDto>>
    {
    }
}
