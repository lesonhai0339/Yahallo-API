using MediatR;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.Reference;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.BlogCommand.Create
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, ResponseResult<string>>
    {
        private IBlogRepository _blogRepository;
        private IAttechmentRepository _attechmentRepository;
        private IThreadOfBlogRepository _threadOfBlogRepository;
        private IThreadRepository _threadRepository;
        private ICurrentUserService _currentUser;
        public CreateBlogCommandHandler(IBlogRepository blogRepository, IAttechmentRepository attechmentRepository, IThreadOfBlogRepository threadOfBlogRepository, ICurrentUserService currentUser,
            IThreadRepository threadRepository)
        {
            _blogRepository = blogRepository;
            _attechmentRepository = attechmentRepository;
            _threadOfBlogRepository = threadOfBlogRepository;
            _currentUser = currentUser;
            _threadRepository = threadRepository;
        }

        public async Task<ResponseResult<string>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var checkAttachmentExists = new List<AttechmentEntity>();
            var checkThreadExists = await _threadRepository.FindAllAsync(x => x.Id.Equals(request.ThreadIds), cancellationToken);
            if(checkThreadExists.Count != request.ThreadIds?.Count)
            {
                throw new NotFoundException("Some Thread Id incorrect");
            }
            if(request.AttechmentIds != null)
            {
                checkAttachmentExists = await _attechmentRepository.FindAllAsync(x=> x.Id.Equals(request.AttechmentIds), cancellationToken);
                if(checkAttachmentExists == null)
                {
                    throw new NotFoundException("AttachmentIds incorrect");
                }
                if(checkAttachmentExists.Count != request.AttechmentIds.Count)
                {
                    throw new NotFoundException("Some Attachment Id incorrect");
                }
            }
            var blogEntity = new BlogEntity()
            {
                ParentId = request.ParentId,
                Title = request.Title,
                Description = request.Description,
                Content = request.Content,
                CreateDate = DateTime.Now,
                IdUserCreate = _currentUser.UserId,
            };
            blogEntity.ThreadOfBlogEntities = request.ThreadIds.Select(x => 
                                                                new ThreadOfBlogEntity(blogId: blogEntity.Id, blog: blogEntity, threadId: x, thread: checkThreadExists.FirstOrDefault(y => y.Id.Equals(x))!)).ToList();
            blogEntity.Attechments = checkAttachmentExists;
            var countingEntity = new CountingEntitity()
            {
                BlogId = blogEntity.Id,
                Blog = blogEntity,
                Type = Domain.Enums.CountingEnums.CountingEnumType.Blog
            };
            blogEntity.ViewCount = countingEntity;
            _blogRepository.Add(blogEntity);
            var result = await _blogRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return new ResponseResult<string>("Create successfully");
            }
            else
            {
                return new ResponseResult<string>("Create Failed");
            }
            throw new NotImplementedException();
        }
    }
}
