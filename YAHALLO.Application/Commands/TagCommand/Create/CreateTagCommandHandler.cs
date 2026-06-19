//AI generated
using MediatR;
using Serilog;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Logger;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.TagCommand.Create
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, string>
    {
        private readonly ITagRepository _tagRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly ILogger _logger;

        public CreateTagCommandHandler(ITagRepository tagRepository, ICurrentUserService currentUser, ILoggerExtension logger)
        {
            _tagRepository = tagRepository;
            _currentUser = currentUser;
            _logger = logger.CreateLogger("Logs/Tags", "Create_tag");
        }

        public async Task<string> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var exists = await _tagRepository.AnyAsync(x => x.Name == request.Name && string.IsNullOrEmpty(x.IdUserDelete), cancellationToken);
            if (exists)
            {
                _logger.Error("Tag already exists: {Name}", request.Name);
                throw new DuplicateException($"Tag '{request.Name}' đã tồn tại");
            }

            var tag = new TagEntity
            {
                Name = request.Name,
                Description = request.Description,
                CreateDate = DateTime.UtcNow,
                IdUserCreate = _currentUser.UserId
            };
            _tagRepository.Add(tag);
            var result = await _tagRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            if (result <= 0)
            {
                _logger.Error("Failed to create tag {Name}", request.Name);
                throw new Exception("Đã gặp lỗi khi tạo tag");
            }

            _logger.Information("Created tag {Id} - {Name}", tag.Id, tag.Name);
            return "Tạo tag thành công";
        }
    }
}
