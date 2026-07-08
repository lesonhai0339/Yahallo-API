using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Author;

namespace YAHALLO.Application.Queries.Features.Public.Author.GetAll
{
    public class GetAllAuthorQuery: IRequest<List<AuthorDto>>
    {
    }
}
