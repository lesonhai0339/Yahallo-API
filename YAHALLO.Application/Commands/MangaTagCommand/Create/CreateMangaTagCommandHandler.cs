//AI generated
using MediatR;
using Serilog;
using YAHALLO.Application.Common.Exceptions;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Logger;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.MangaTagCommand.Create
{
    public class CreateMangaTagCommandHandler : IRequestHandler<CreateMangaTagCommand, string>
    {
        private readonly IMangaTagRepository _mangaTagRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly ILogger _logger;

        public CreateMangaTagCommandHandler(
            IMangaTagRepository mangaTagRepository,
            IMangaRepository mangaRepository,
            ITagRepository tagRepository,
            ICurrentUserService currentUser,
            ILoggerExtension logger)
        {
            _mangaTagRepository = mangaTagRepository;
            _mangaRepository = mangaRepository;
            _tagRepository = tagRepository;
            _currentUser = currentUser;
            _logger = logger.CreateLogger("Logs/Tags", "Create_mangatag");
        }

        public async Task<string> Handle(CreateMangaTagCommand request, CancellationToken cancellationToken)
        {
            var mangaExists = await _mangaRepository.AnyAsync(x => x.Id == request.MangaId && string.IsNullOrEmpty(x.IdUserDelete), cancellationToken);
            if (!mangaExists) throw new NotFoundException($"Không tìm thấy manga: {request.MangaId}");

            var tagExists = await _tagRepository.AnyAsync(x => x.Id == request.TagId && string.IsNullOrEmpty(x.IdUserDelete), cancellationToken);
            if (!tagExists) throw new NotFoundException($"Không tìm thấy tag: {request.TagId}");

            var alreadyLinked = await _mangaTagRepository.AnyAsync(x => x.MangaId == request.MangaId && x.TagId == request.TagId, cancellationToken);
            if (alreadyLinked) throw new ConflictException("Manga đã được gắn tag này");

            var mangaTag = new MangaTagEntity
            {
                MangaId = request.MangaId,
                TagId = request.TagId,
                CreateDate = DateTime.UtcNow,
                IdUserCreate = _currentUser.UserId
            };
            _mangaTagRepository.Add(mangaTag);
            await _mangaTagRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            _logger.Information("Linked manga {MangaId} -> tag {TagId}", request.MangaId, request.TagId);
            return "Gắn tag cho manga thành công";
        }
    }
}
