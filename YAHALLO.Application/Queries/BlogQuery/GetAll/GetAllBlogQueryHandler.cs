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

namespace YAHALLO.Application.Queries.BlogQuery.GetAll
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery, ResponseResult<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetAllBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<ResponseResult<BlogDto>> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
        {
            var checkBlogExists = await _blogRepository.FindAllAsync(x=> string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue ,cancellationToken);
            if(checkBlogExists == null) 
            {
                throw new NotFoundException("Does not exist any blog");
            }
            return new ResponseResult<BlogDto>(checkBlogExists.MapToBlogDtoToList(_mapper).ToList());
        }
    }
}
