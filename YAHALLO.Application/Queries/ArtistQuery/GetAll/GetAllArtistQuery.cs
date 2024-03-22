using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.ArtistQuery.GetAll
{
    public class GetAllArtistQuery: IRequest<List<ArtistDto>>
    {
        public GetAllArtistQuery() { }
    }
}
