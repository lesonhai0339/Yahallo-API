using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.ArtistQuery.GetAllDeleted
{
    public class GetAllArtistDeletedQuery : IRequest<List<ArtistDto>>
    {
        public GetAllArtistDeletedQuery() { }
    }
}
