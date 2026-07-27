using MediatR;
using System.Data;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Chapter.GetImage
{
    public class GetImageQueryHandler : IRequestHandler<GetImageQuery, List<ChapterImageDto>>
    {
        private readonly IChapterImageRepository _imageRepository;
        public GetImageQueryHandler(IChapterImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<List<ChapterImageDto>> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var images = await _imageRepository
                .FindAllSelectAsync(x => x
                    .Where(i => i.ChapterId == request.ChapterId)
                    .OrderBy(x => x.Index)
                    .Select(x => new ChapterImageDto 
                    { 
                        Id = x.Id,
                        ContentType = x.ContentType,
                        Height = x.Height,
                        Index = x.Index,
                        ResizeHeight = x.ResizeHeight,
                        ResizeUrl = x.ResizeUrl,    
                        ResizeWidth = x.ResizeWidth,    
                        Url = x.Url,    
                        Width = x.Width 
                    })
                    .OrderBy(x => x.Index),
                    cancellationToken
                );
            return images;
        }
    }
}
