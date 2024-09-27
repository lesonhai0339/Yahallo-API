using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.AttechmentQuery.GetAll
{
    public class GetAllAttechmentQuery: IRequest<ResponseResult<AttechmentDto>>
    {
        public GetAllAttechmentQuery() { }  
    }
}
