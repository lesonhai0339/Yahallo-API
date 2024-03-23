using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.AuthorQuery.GetAllDeleted
{
    public class GetAllAuthorDeletedQueryHandler : IRequestHandler<GetAllAuthorDeletedQuery, List<AuthorDto>>
    {
        private readonly IAuthorRepository _authorReoisitory;
        private readonly IMapper _mapper;
        public GetAllAuthorDeletedQueryHandler(IAuthorRepository authorReoisitory, IMapper mapper)
        {
            _authorReoisitory = authorReoisitory;
            _mapper = mapper;
        }
        public async Task<List<AuthorDto>> Handle(GetAllAuthorDeletedQuery request, CancellationToken cancellationToken)
        {
            var listAuthors = await _authorReoisitory
                            .FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (!listAuthors.Any())
            {
                throw new NotFoundException("Không tìm thấy bất kỳ họa sĩ nào");
            }
            return listAuthors.MapToAuthorDtoToList(_mapper);
        }
    }
}
