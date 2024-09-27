using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.BlogQuery.GetAllDeleted
{
    public class GetAllBlogDeletedQueryHandler : IRequestHandler<GetAllBlogDeletedQuery, ResponseResult<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetAllBlogDeletedQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
    
        public async Task<ResponseResult<BlogDto>> Handle(GetAllBlogDeletedQuery request, CancellationToken cancellationToken)
        {
            var checkBlogExists = await _blogRepository.FindAllAsync(x=> !string.IsNullOrWhiteSpace(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if(checkBlogExists.Count() == 0)
            {
                throw new NotFoundException("Does not exist any blog have deleted");
            }
            return new ResponseResult<BlogDto>(checkBlogExists.MapToBlogDtoToList(_mapper).ToList());
        }
    }
}
