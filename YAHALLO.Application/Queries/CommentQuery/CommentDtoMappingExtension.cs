using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.CommentQuery
{
    public static class CommentDtoMappingExtension
    {
        public static CommentDto MapToCommentDto(this CommentEntity entity, IMapper mapper)
            => mapper.Map<CommentDto>(entity);  
        public static List<CommentDto> MapToCommentDtoToList(this ICollection<CommentEntity> entities, IMapper mapper)
            => entities.Select(x=> x.MapToCommentDto(mapper)).ToList();

        public static CommentDto MapFullToCommentDto(this CommentEntity entity, IMapper mapper)
        {
            var map= mapper.Map<CommentDto>(entity);
            return map; 
        }
        public static List<CommentDto> MapFullCommentDtoToList(this ICollection<CommentEntity> entities, IMapper mapper)
            => entities.Select(x=> x.MapFullToCommentDto(mapper)).ToList();
    }
}
