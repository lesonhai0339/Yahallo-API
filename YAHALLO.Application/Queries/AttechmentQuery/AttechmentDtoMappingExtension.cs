using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Reference;

namespace YAHALLO.Application.Queries.AttechmentQuery
{
    public static class AttechmentDtoMappingExtension
    {
        public static AttechmentDto MapToAttechmentDto(this AttechmentEntity entity, IMapper mapper)
            => mapper.Map<AttechmentDto>(entity);  
        public static IEnumerable<AttechmentDto> MapToAttechmentDtoToList(this IEnumerable<AttechmentEntity> entities, IMapper mapper)
            => entities.Select(x=> x.MapToAttechmentDto(mapper)).ToList();
        public static AttechmentDto MapFullToAttechmentDto(this AttechmentEntity entity, IMapper mapper)
        {
            var map = mapper.Map<AttechmentDto>(entity);
            //some properties
            return map;
        }
        public static IEnumerable<AttechmentDto> MapFullToAttechmentDtoToList(this IEnumerable<AttechmentEntity> entities, IMapper mapper)
            => entities.Select(x=> x.MapFullToAttechmentDto(mapper)).ToList();
    }
}
