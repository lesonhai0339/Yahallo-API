using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.ReportEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ReportCommand.Create
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, ResponseResult<string>>
    {
        private readonly IReportRepository _reportRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IUserRepository _userRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly IChapterRepository _chapterRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IEnums _enums;
        public CreateReportCommandHandler(IReportRepository reportRepository, ICurrentUserService currentUser, IUserRepository userRepository, IMangaRepository mangaRepository, 
            IChapterRepository chapterRepository, IBlogRepository blogRepository, IEnums enums)
        {
            _reportRepository = reportRepository;
            _currentUser = currentUser;
            _userRepository = userRepository;
            _mangaRepository = mangaRepository;
            _chapterRepository = chapterRepository;
            _blogRepository = blogRepository;
            _enums = enums;
        }

        public async Task<ResponseResult<string>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            object? parent= new object();
            var classEntity = _enums.GetClassFromEnum(request.Type);
            if (classEntity == null) 
            {
                throw new NotFoundException($"Không tìm thấy đối tượng report");
            }
            if(request.Type == ReportEnumType.MangaEntity)
            {
                parent = await _mangaRepository.FindAsync(x=> x.Id == request.Target && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue , cancellationToken);
            }
            else if (request.Type == ReportEnumType.UserEntity)
            {
                parent = await _userRepository.FindAsync(x => x.Id == request.Target && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            }
            else if (request.Type == ReportEnumType.ChapterEntity)
            {
                parent = await _chapterRepository.FindAsync(x => x.Id == request.Target && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            }
            else if (request.Type == ReportEnumType.BlogEntity)
            {
                parent = await _blogRepository.FindAsync(x => x.Id == request.Target && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            }
            if(parent == null) 
            {
                throw new NotFoundException($"Không tìm thấy đối tượng report");
            }
            
            throw new NotImplementedException();
        }
        /*public async Task<ResponseResult<string>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            string proc = "Id";
            //tạo 1 dictionary vói key là typeof của đối tượng còn value là queryable của đối tượng
            //Create a dictionary with key is typeof and value is a queryable of entity
            _dictionary = new Dictionary<Type, Func<IQueryable<object>>>
         {
             { typeof(UserEntity), _userRepository.CreateQueryable().Cast<object> },
             { typeof(MangaEntity), _mangaRepository.CreateQueryable().Cast<object>  },
             { typeof(ChapterEntity),_chapterRepository.CreateQueryable().Cast<object>  },
             { typeof(BlogEntity),_blogRepository.CreateQueryable().Cast<object>  },
         };
            //lấy class của enum
            //get enum class
            var classEntity = _enums.GetClassFromEnum(request.Type);
            if (classEntity == null)
            {
                throw new NotFoundException("Không tìm thấy đối tượng");
            }
            var classEntityType = classEntity!.GetType();
            //thử lấy value của dictionary bằng type của enum
            //try get value in dictionary from type of enum
            if (_dictionary.TryGetValue(classEntityType, out var queryableFunc))
            {
                //lấy danh sách thuộc tính và tìm tuộc tính Id
                //get properties and find Id property
                var queryable = queryableFunc();
                var query = queryable.AsQueryable();
                var entityType = query.ElementType;
                var idProperty = entityType.GetProperty(proc);
                if (idProperty == null)
                {
                    throw new InvalidOperationException($"Thuộc tính {proc} không tồn tại trong đối tượng");
                }
                // tìm đối tượng với thuộc tính Id
                //look for entity with Id property
                var target = await query
                    .FirstOrDefaultAsync(x => (string?)idProperty.GetValue(x) == request.Target);

                if (target != null)
                {
                    return new ResponseResult<string>("Success");
                }
                else
                {
                    throw new NotFoundException("Không tìm thấy đối tượng trong repository");
                }

            }
            return new ResponseResult<string>("");
         }*/
    }
}
