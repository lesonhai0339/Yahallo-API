using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.AttechmentCommand.Create
{
    public class CreateAttechmentCommandHandler : IRequestHandler<CreateAttechmentCommand, ResponseResult<string>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IFiles<IFormFile> _files;
        private readonly ICurrentUserService _currentUser;
        private readonly IAttechmentRepository _attechmentRepository;
        private readonly IBlogRepository _blogRepository;
        private MangaEntity? _manga;
        private ChapterEntity? _chapter;
        public CreateAttechmentCommandHandler(ICommentRepository commentRepository,
            IFiles<IFormFile> files, ICurrentUserService currentUser, IAttechmentRepository attechmentRepository, IBlogRepository blogRepository)
        {
            _commentRepository = commentRepository;
            _currentUser = currentUser;
            _attechmentRepository = attechmentRepository;
            _blogRepository = blogRepository;
            _files = files;
            _manga = null;
            _chapter = null;
        }
        public async Task<ResponseResult<string>> Handle(CreateAttechmentCommand request, CancellationToken cancellationToken)
        {
            string? url_1 = request.Url1;
            string? url_2 = request.Url2;
            string? url_3 = request.Url3;
            Tuple<string,string>? entity = new Tuple<string, string>("","");
            if(request.CommentId != null)
            {
                entity = new Tuple<string,string>("Comment", request.CommentId);
            }
            else
            {
                entity = new Tuple<string, string>("Blog", request.BlogId!);
            }
            object? checkEntityExist = (entity.Item1 == "Comment")
                ? await _commentRepository.FindAsync(x => x.Id == entity.Item2 && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken)
                : await _blogRepository.FindAsync(x => x.Id == entity.Item2 && string.IsNullOrEmpty(x.IdUserDelete) && !x.DeleteDate.HasValue, cancellationToken);
            if(checkEntityExist == null)
            {
                throw new NotFoundException($"{entity.Item1} với Id {entity.Item2} không tồn tại");
            }
            AttechmentEntity attechment = new AttechmentEntity
            {
                Description = request.Description,
                MediaType = request.MediaType,
                Title = request.Title,
                Url1 = request.Url1,
                Url2 = request.Url2,
                Url3 = request.Url3,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.Now,
                CommentId = (entity.Item1 =="Comment") ? entity.Item2 : null,
                Comment = (entity.Item1 == "Comment") ? (CommentEntity)checkEntityExist : null,
                BlogId = (entity.Item1 == "Blog") ? entity.Item2 : null,
                Blog = (entity.Item1 == "Blog") ? (BlogEntity)checkEntityExist : null,
            };
            if (request.IsHaveMedia == true)
            {
                if (request.MediaFile != null)
                {
                    string? parent_folder = _manga?.Id ?? _chapter?.Id;
                    if (parent_folder != null)
                    {
                        try
                        {
                            var path = $"Data\\Comments\\{parent_folder}";
                            _files.CreateFolder(path);
                            bool check = await _files.UpLoadimage(request.MediaFile, path);
                            if (check)
                            {
                                url_1 = Path.Combine(path, request.MediaFile.FileName);
                                attechment.Url1 = url_1;
                            }
                        }
                        catch (IOException e)
                        {
                            throw new IOException("Lỗi trong quá trình ghi data: ", e);
                        }
                    }
                }
            }
            _attechmentRepository.Add(attechment);
            var result = await _attechmentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return new ResponseResult<string>("Tạo thành công");
            }
            else
            {
                return new ResponseResult<string>("Tạo thất bại");
            }
        }
    }
}
