using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Queries.BlogQuery.GetAll
{
    public class GetAllBlogQuery: IRequest<ResponseResult<BlogDto>>
    {
        public GetAllBlogQuery() { }    
    }
}
