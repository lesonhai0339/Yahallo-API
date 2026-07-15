using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Application.Queries.Features.Public.Manga.DTOs;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Tag.GetById
{
    public class GetTagInfoByIdQueryHandler : IRequestHandler<GetTagInfoByIdQuery, TagDto>
    {
        private readonly ITagRepository _tagRepository;
        public GetTagInfoByIdQueryHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<TagDto> Handle(GetTagInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.FindSelectAsync(x => x
                .Where(t => t.Id == request.Id)
                .Select(x => new TagDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name
                }),
                cancellationToken);

            if(tag == null)
                throw new NotFoundException($"Cannot find tag with id {request.Id}");

            return tag;
        }
    }
}
