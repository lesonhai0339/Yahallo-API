using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Features.Public.Artist.GetAll
{
    public class GetAllArtistQuery: IRequest<List<GetAllArtistResult>>
    {
    }
    public record GetAllArtistResult
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
