using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ChapterCommand.Create
{
    public class CreateChapterCommandHandler : IRequestHandler<CreateChapterCommand, string>
    {
        private IMangaRepository _mangaRepository;
        private ICurrentUserService _currentUser;
        public CreateChapterCommandHandler(
            IMangaRepository mangaRepository, 
            ICurrentUserService currentUser)
        {
            _mangaRepository = mangaRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(CreateChapterCommand request, CancellationToken cancellationToken)
        {

            var manga = await _mangaRepository.FindAsync(x => x.Id == request.MangaId, cancellationToken);
            if(manga == null)
                throw new NotFoundException($"Manga with id {request.MangaId} not found");
            var chapter = new ChapterEntity
            {
                Title = string.IsNullOrEmpty(request.Title) ? $"Chương {request.Index}" : request.Title,
                Index = request.Index,
                SubIndex = request.SubIndex,    
                MangaId = request.MangaId,
                IdUserCreate = _currentUser.UserId,
                CreateDate = DateTime.UtcNow,

            };

            manga.ChaptersEntities.Add(chapter);

            manga.LastChapterId = chapter.Id;
            manga.LastChapterIndex = chapter.Index;
            manga.LastChapterUpdate = chapter.CreateDate;
            manga.LastChapter = chapter;

            var result = await _mangaRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result == 0)
                throw new Exception("Tạo chapter thất bại");

            return chapter.Id;
        }
    }
}
