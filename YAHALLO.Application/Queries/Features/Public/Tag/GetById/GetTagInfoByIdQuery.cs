using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.Features.Public.Tag.GetById
{
    public class GetTagInfoByIdQuery: IRequest<TagDto>
    {
        public string Id { get; init; } = null!;
    }
}
