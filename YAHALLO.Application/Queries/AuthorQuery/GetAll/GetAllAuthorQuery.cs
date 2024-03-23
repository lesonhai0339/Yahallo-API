using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.AuthorQuery.GetAll
{
    public class GetAllAuthorQuery: IRequest<List<AuthorDto>>
    {
        public GetAllAuthorQuery() { }
    }
}
