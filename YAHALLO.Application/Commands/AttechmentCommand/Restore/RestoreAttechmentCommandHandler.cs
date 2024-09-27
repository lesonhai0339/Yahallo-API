using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AttechmentCommand.Restore
{
    public class RestoreAttechmentCommandHandler : IRequestHandler<RestoreAttechmentCommand, ResponseResult<string>>
    {
        private readonly IAttechmentRepository _attechmentRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreAttechmentCommandHandler(IAttechmentRepository attechmentRepository, ICurrentUserService currentUser)
        {
            _attechmentRepository = attechmentRepository;
            _currentUser = currentUser;
        }
    
        public async Task<ResponseResult<string>> Handle(RestoreAttechmentCommand request, CancellationToken cancellationToken)
        {
            var checkAttechmentExist= await _attechmentRepository.FindAsync(x=> x.Id == request.Id, cancellationToken);
            if (checkAttechmentExist == null)
            {
                throw new NotFoundException($"Does not exist attechment with Id {request.Id}");
            }
            if(checkAttechmentExist.IdUserCreate != _currentUser.UserId || !await _currentUser.IsInRoleAsync("Admin"))
            {
                throw new UnAuthorizeException("You don't have permission");
            }
            if(string.IsNullOrEmpty(checkAttechmentExist.IdUserDelete) && !checkAttechmentExist.DeleteDate.HasValue)
            {
                throw new NotFoundException($"Does not exist attechment with Id {request.Id} had deleted");
            }
            checkAttechmentExist.IdUserDelete = null;
            checkAttechmentExist.DeleteDate = null;
            checkAttechmentExist.IdUserUpdate = _currentUser.UserId;
            checkAttechmentExist.UpdateDate = DateTime.Now;
            _attechmentRepository.Update(checkAttechmentExist);
            var result = await _attechmentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result >0)
            {
                return new ResponseResult<string>("Restore successfully");
            }
            else
            {
                return new ResponseResult<string>("Restore failed");
            }
        }
    }
}
