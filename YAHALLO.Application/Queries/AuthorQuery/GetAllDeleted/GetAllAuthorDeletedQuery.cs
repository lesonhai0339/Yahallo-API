using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.AuthorQuery.GetAllDeleted
{
    public class GetAllAuthorDeletedQuery: IRequest<List<AuthorDto>>
    {
        public GetAllAuthorDeletedQuery() { }
    }
}
