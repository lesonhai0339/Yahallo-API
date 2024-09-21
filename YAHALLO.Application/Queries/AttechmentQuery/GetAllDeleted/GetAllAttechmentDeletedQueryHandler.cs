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

namespace YAHALLO.Application.Queries.AttechmentQuery.GetAllDeleted
{
    public class GetAllAttechmentDeletedQueryHandler : IRequestHandler<GetAllAttechmentDeletedQuery, ResponseResult<AttechmentDto>>
    {
        private readonly IAttechmentRepository _attechmentRepository;
        private readonly IMapper _mapper;
        public GetAllAttechmentDeletedQueryHandler(IAttechmentRepository attechmentRepository, IMapper mapper)
        {
            _attechmentRepository = attechmentRepository;
            _mapper = mapper;
        }

        public async Task<ResponseResult<AttechmentDto>> Handle(GetAllAttechmentDeletedQuery request, CancellationToken cancellationToken)
        {
            var chechAttechmentExist = await _attechmentRepository.FindAllAsync(x => !string.IsNullOrEmpty(x.IdUserDelete) && x.DeleteDate.HasValue, cancellationToken);
            if (chechAttechmentExist.Count() == 0)
            {
                throw new NotFoundException("Do not have any attechment");
            }
            return new ResponseResult<AttechmentDto>(chechAttechmentExist.MapToAttechmentDtoToList(_mapper).ToList());
        }
    }
}
