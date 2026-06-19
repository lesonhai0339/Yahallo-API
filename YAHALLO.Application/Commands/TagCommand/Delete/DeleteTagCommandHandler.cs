//AI generated
using MediatR;
using Serilog;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Logger;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.TagCommand.Delete
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, string>
    {
        private readonly ITagRepository _tagRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly ILogger _logger;

        public DeleteTagCommandHandler(ITagRepository tagRepository, ICurrentUserService currentUser, ILoggerExtension logger)
        {
            _tagRepository = tagRepository;
            _currentUser = currentUser;
            _logger = logger.CreateLogger("Logs/Tags", "Delete_tag");
        }

        public async Task<string> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete), cancellationToken);
            if (tag is null)
            {
                _logger.Error("Tag not found: {Id}", request.Id);
                throw new NotFoundException($"Không tìm thấy tag với Id: {request.Id}");
            }

            tag.DeleteDate = DateTime.UtcNow;
            tag.IdUserDelete = _currentUser.UserId;
            _tagRepository.Update(tag);
            await _tagRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            _logger.Information("Deleted tag {Id}", tag.Id);
            return "Xóa tag thành công";
        }
    }
}
