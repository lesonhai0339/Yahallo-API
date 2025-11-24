using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Security.Get
{
    public class GetPublicKeyQuery: IRequest<string>
    {
        public GetPublicKeyQuery() { }
    }
}
