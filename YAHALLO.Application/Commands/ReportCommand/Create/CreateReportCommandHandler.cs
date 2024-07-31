using LinqKit;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pkcs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Enums.ReportEnums;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using static YAHALLO.Application.Commands.ReportCommand.Create.CreateReportCommandHandler;

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
        private readonly IFiles<IFormFile> _files
        public CreateReportCommandHandler(IReportRepository reportRepository, ICurrentUserService currentUser, IUserRepository userRepository, IMangaRepository mangaRepository, 
            IChapterRepository chapterRepository, IBlogRepository blogRepository, IEnums enums, IFiles<IFormFile> files)
        {
            _reportRepository = reportRepository;
            _currentUser = currentUser;
            _userRepository = userRepository;
            _mangaRepository = mangaRepository;
            _chapterRepository = chapterRepository;
            _blogRepository = blogRepository;
            _enums = enums;
            _files = files;
        }

        public async Task<ResponseResult<string>> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var classEntity = _enums.GetClassFromEnum(request.Type);
            if (classEntity == null) 
            {
                throw new NotFoundException($"Không tìm thấy đối tượng report");
            }
            var reportEntity = new ReportEntity(); 
            if (classEntity is UserEntity)
            {
                classEntity =await _userRepository.FindAsync(x=> x.Id == request.Target && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
                reportEntity.Type = ReportEnumType.UserEntity;
            }
            else if (classEntity is MangaEntity)
            {
                classEntity = await _mangaRepository.FindAsync(x => x.Id == request.Target && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
                reportEntity.Type = ReportEnumType.MangaEntity;
            }
            else if (classEntity is ChapterEntity)
            {
                classEntity = await _chapterRepository.FindAsync(x => x.Id == request.Target && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
                reportEntity.Type = ReportEnumType.ChapterEntity;
            }
            else if (classEntity is BlogEntity)
            {
                classEntity = await _blogRepository.FindAsync(x => x.Id == request.Target && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue);
                reportEntity.Type = ReportEnumType.BlogEntity;
            }
            if (classEntity == null)
            {
                throw new NotFoundException($"Không tìm thấy đối tượng report");
            }
            reportEntity.Title = request.Title ??"";
            reportEntity.Content = request.Content ?? "";
            reportEntity.Description = request.Description ?? "";
            reportEntity.IdUserCreate = _currentUser.UserId;
            reportEntity.CreateDate = DateTime.Now;
            reportEntity.IdUserReport = _currentUser.UserId;
            reportEntity.Attechments = request.Media!.Select(x =>
            {
                //Add media to dicrectory (not finish)
                //.....................(code)
                //
                AttechmentEntity attech = new AttechmentEntity
                {
                    Description = "Report",
                    MediaType = Domain.Enums.UserEnums.CommentMediaType.Image,
                    Title = "Report media",
                    Url1 = "Not",
                };
                return attech;
            }).ToList();
            _reportRepository.Add(reportEntity);
            var result = await _reportRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return new ResponseResult<string>("Thành công");
            }
            else
            {
                return new ResponseResult<string>("Thất bại");
            }
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
