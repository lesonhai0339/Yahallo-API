using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;

namespace YAHALLO.Application.Queries.AuthorQuery
{
    public static class AuthorDtoMappingExtension
    {
        public static AuthorDto MapToAuthorDto(this AuthorEntity entity, IMapper mapper)=>
            mapper.Map<AuthorDto>(entity);
        public static List<AuthorDto> MapToAuthorDtoToList(this IEnumerable<AuthorEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToAuthorDto(mapper)).ToList();
    }
}
