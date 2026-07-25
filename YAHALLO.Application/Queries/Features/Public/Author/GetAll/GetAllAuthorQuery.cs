using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Features.Public.Author.GetAll
{
    public class GetAllAuthorQuery: IRequest<List<GetAllAuthorResult>>
    {
    }
    public record GetAllAuthorResult
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
