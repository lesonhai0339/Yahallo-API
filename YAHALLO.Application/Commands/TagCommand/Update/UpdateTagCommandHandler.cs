//AI generated
using MediatR;
using Serilog;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Logger;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.TagCommand.Update
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, string>
    {
        private readonly ITagRepository _tagRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly ILogger _logger;

        public UpdateTagCommandHandler(ITagRepository tagRepository, ICurrentUserService currentUser, ILoggerExtension logger)
        {
            _tagRepository = tagRepository;
            _currentUser = currentUser;
            _logger = logger.CreateLogger("Logs/Tags", "Update_tag");
        }

        public async Task<string> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.FindAsync(x => x.Id == request.Id && string.IsNullOrEmpty(x.IdUserDelete), cancellationToken);
            if (tag is null)
            {
                _logger.Error("Tag not found: {Id}", request.Id);
                throw new NotFoundException($"Không tìm thấy tag với Id: {request.Id}");
            }

            if (!string.IsNullOrEmpty(request.Name)) tag.Name = request.Name;
            if (request.Description is not null) tag.Description = request.Description;
            tag.UpdateDate = DateTime.Now;
            tag.IdUserUpdate = _currentUser.UserId;

            _tagRepository.Update(tag);
            await _tagRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            _logger.Information("Updated tag {Id}", tag.Id);
            return "Cập nhật tag thành công";
        }
    }
}
