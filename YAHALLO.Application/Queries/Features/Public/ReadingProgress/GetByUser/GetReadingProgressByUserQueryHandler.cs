//AI generated
using AutoMapper;
using MediatR;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Queries.Features.Public.ReadingProgress;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.ReadingProgress.GetByUser
{
    public class GetReadingProgressByUserQueryHandler : IRequestHandler<GetReadingProgressByUserQuery, List<ReadingProgressDto>>
    {
        private readonly IReadingProgressRepository _progressRepository;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public GetReadingProgressByUserQueryHandler(IReadingProgressRepository progressRepository, ICurrentUserService currentUser, IMapper mapper)
        {
            _progressRepository = progressRepository;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<List<ReadingProgressDto>> Handle(GetReadingProgressByUserQuery request, CancellationToken cancellationToken)
        {
            var userId = request.UserId ?? _currentUser.UserId;
            if (string.IsNullOrEmpty(userId))
                throw new UnAuthorizeException("Bạn cần đăng nhập để xem tiến độ đọc");

            var list = await _progressRepository.FindAllAsync(query =>
            {
                query = query.Where(x => x.UserId == userId);
                if (!string.IsNullOrEmpty(request.MangaId))
                    query = query.Where(x => x.MangaId == request.MangaId);
                return query;
            }, cancellationToken);
            return list.Select(x => _mapper.Map<ReadingProgressDto>(x)).ToList();
        }
    }
}
