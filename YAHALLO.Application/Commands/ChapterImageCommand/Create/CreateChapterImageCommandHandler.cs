using MediatR;
using System.Xml;
using YAHALLO.Application.Common.Helper;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Storage;
using YAHALLO.Domain.S3;

namespace YAHALLO.Application.Commands.ChapterImageCommand.Create
{
    public class CreateChapterImageCommandHandler : IRequestHandler<CreateChapterImageCommand, CreateChapterImageResult>
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IStorageService<ChapterImage> _storageService;
        public CreateChapterImageCommandHandler(IChapterRepository chapterRepository, ICurrentUserService currentUserService, IStorageService<ChapterImage> storageService)
        {
            _chapterRepository = chapterRepository;
            _currentUserService = currentUserService;
            _storageService = storageService;
        }
        public async Task<CreateChapterImageResult> Handle(CreateChapterImageCommand request, CancellationToken cancellationToken)
        {
            var chapter = await _chapterRepository.FindAsync(x => x.Id == request.ChapterId);
            if (chapter == null)
                throw new NotFoundException($"Cannot find chapter with id {request.ChapterId}");


            var signedUrls = request.FileUploadInfo.Select(async (item) =>
            {
                return item == null ? null : await _storageService.CreateSignedURL(new ChapterImage
                {
                    Id = chapter.Id,
                    MangaId = chapter.MangaId,  
                    FileName = item.FileName,
                    ContentType = item.ContentType,
                    FileSize = item.Length,
                    Width = item.Width,
                    Height = item.Height,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending
                });
            });

            var response = await Task.WhenAll(signedUrls);  
            var urls = response.OfType<S3Response>().ToList();

            var pairs = urls.Select((item, index) => new
            {   
                UploadUrl = item.Url,
                Entity =  new ChapterImageEntity
                {
                    Index = index,
                    Url = S3UrlHelper.ToCloudFrontUrl(item?.Url!, item?.CloundFrontDomain),
                    Width = item!.Width,
                    Height = item.Height,
                    ContentType = item.ContentType,
                    Status = Domain.Enums.FileUpload.FileUploadStatus.Pending,
                    ChapterId = chapter.Id,
                    IdUserCreate = _currentUserService.UserId,
                    CreateDate = DateTime.UtcNow,
                }
            }).ToList();

            //chapter.TotalImage += pairs.Count;
            chapter.ImagesEntities = pairs.Select(x => x.Entity).ToList();
            _chapterRepository.Update(chapter); 

            var result = await _chapterRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateChapterImageResult
            {
                Data = pairs.Select(x => new CreateChapterImageItem
                {
                    Id = x.Entity.Id,  
                    Index = x.Entity.Index,
                    UploadUrl = x.UploadUrl!,
                    ChapterId = x.Entity.ChapterId
                }).ToList()
            };
        }
    }
}
