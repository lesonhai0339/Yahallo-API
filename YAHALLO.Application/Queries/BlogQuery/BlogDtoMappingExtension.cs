using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.BlogQuery
{
    public static class BlogDtoMappingExtension
    {
        public static BlogDto MapToBlogDto(this BlogEntity entity, IMapper mapper)
            => mapper.Map<BlogDto>(entity); 
        public static IEnumerable<BlogDto> MapToBlogDtoToList(this IEnumerable<BlogEntity> entities, IMapper mapper)    
            => entities.Select(x=> x.MapToBlogDto(mapper)).ToList();
    }
}
