using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Attechment;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.Features.Public.Attechment.GetAll
{
    public class GetAllAttechmentQuery: IRequest<ResponseResult<AttechmentDto>>
    {  
    }
}
