using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.Base;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AuthorCommand.Create
{
    public class CreateAuthorCommandhandler : IRequestHandler<CreateAuthorCommand, string>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateAuthorCommandhandler(IAuthorRepository authorRepository, ICurrentUserService currentUser)
        {
            _authorRepository = authorRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Func<IQueryable<AuthorEntity>, IQueryable<AuthorEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(x => x.Name == request.Name);
                }
                if (request.Countries != 0)
                {
                    query = query.Where(x => x.Countries == request.Countries);
                }
                query = query.Where(x => x.Depscription == request.Depscription);
                query = query.Where(x => x.Birth == request.Birth);
                query = query.Where(x => x.LifeStatus == request.LifeStatus);
                return query;
            };
            var checkAuthorExist = await _authorRepository.FindAsync(options, cancellationToken);
            if(checkAuthorExist !=null)
            {
                throw new DuplicateException("Đã tồn tại tác giả với thông tin tương tự");
            }
            var newAuthor = new AuthorEntity
            {
                Name = request.Name,
                Depscription = request.Depscription,
                Countries = (CountriesEnum)request.Countries,
                Birth = request.Birth,
                LifeStatus = (LifeStatus)request.LifeStatus,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.Now
            };
            _authorRepository.Add(newAuthor);
            var result= await _authorRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return "Tạo thành công";
            }
            else
            {
                return "Tạo thất bại";
            }
        }
    }
}
