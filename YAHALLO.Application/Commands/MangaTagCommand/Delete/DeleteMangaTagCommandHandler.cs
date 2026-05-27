//AI generated
using MediatR;
using Serilog;
using YAHALLO.Application.Common.Logger;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaTagCommand.Delete
{
    public class DeleteMangaTagCommandHandler : IRequestHandler<DeleteMangaTagCommand, string>
    {
        private readonly IMangaTagRepository _mangaTagRepository;
        private readonly ILogger _logger;

        public DeleteMangaTagCommandHandler(IMangaTagRepository mangaTagRepository, ILoggerExtension logger)
        {
            _mangaTagRepository = mangaTagRepository;
            _logger = logger.CreateLogger("Logs/Tags", "Delete_mangatag");
        }

        public async Task<string> Handle(DeleteMangaTagCommand request, CancellationToken cancellationToken)
        {
            var link = await _mangaTagRepository.FindAsync(x => x.MangaId == request.MangaId && x.TagId == request.TagId, cancellationToken);
            if (link is null) throw new NotFoundException("Không tìm thấy liên kết manga-tag");

            _mangaTagRepository.Remove(link);
            await _mangaTagRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            _logger.Information("Removed tag {TagId} from manga {MangaId}", request.TagId, request.MangaId);
            return "Gỡ tag khỏi manga thành công";
        }
    }
}
