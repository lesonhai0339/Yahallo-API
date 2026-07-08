using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Author;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Author.GetAll
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, List<AuthorDto>>
    {
        private readonly IAuthorRepository _authorReoisitory;
        private readonly IMapper _mapper;
        public GetAllAuthorQueryHandler(IAuthorRepository authorReoisitory, IMapper mapper)
        {
            _authorReoisitory = authorReoisitory;
            _mapper = mapper;
        }

        public async Task<List<AuthorDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorReoisitory
                .FindAllAsync(x=> string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            return authors.MapToAuthorDtoToList(_mapper);
        }
    }
}
