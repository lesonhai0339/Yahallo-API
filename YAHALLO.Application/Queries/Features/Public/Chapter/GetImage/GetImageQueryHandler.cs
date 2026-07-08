using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.Chapter;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Chapter.GetImage
{
    public class GetImageQueryHandler : IRequestHandler<GetImageQuery, List<ChapterImageDto>>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;
        public GetImageQueryHandler(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }
        public async Task<List<ChapterImageDto>> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var images = await _imageRepository.FindAllAsync(
                filterExpression: x =>
                string.IsNullOrEmpty(x.IdUserDelete)
                && !x.DeleteDate.HasValue
                && x.ChapterId == request.ChapterId,
                cancellationToken);
            if(images == null || !images.Any())
                throw new DataException("Không tìm thấy ảnh nào cho chapter này");

            return images.MapFullToChapterImageDtoToList(_mapper);
        }
    }
}
