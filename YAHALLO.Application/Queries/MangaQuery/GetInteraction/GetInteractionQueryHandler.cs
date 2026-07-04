using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Queries.MangaQuery.DTOs;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.MangaQuery.GetInteraction
{
    public class GetInteractionQueryHandler : IRequestHandler<GetInteractionQuery, GetInteractionQueryResult>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IMangaRepository _mangaRepository;
        public GetInteractionQueryHandler(ICurrentUserService currentUser, IMangaRepository mangaRepository)
        {
            _currentUser = currentUser;
            _mangaRepository = mangaRepository;
        }
        public async Task<GetInteractionQueryResult> Handle(GetInteractionQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("");

            var interaction = await _mangaRepository.FindSelectAsync(x => x
                .Where(m => m.Id == request.MangaId)
                .Select(m => new InteractionDto {
                    MangaId = m.Id,
                    RatingId = m.RatingEntities.FirstOrDefault(r => r.UserId == _currentUser.UserId) != null ? m.RatingEntities.FirstOrDefault(r => r.UserId == _currentUser.UserId)!.Id : null,
                    Rating = m.RatingEntities.FirstOrDefault(r => r.UserId == _currentUser.UserId) != null ? m.RatingEntities.FirstOrDefault(r => r.UserId == _currentUser.UserId)!.Rating : null,
                    Following =  m.FollowEntities.FirstOrDefault(f => f.UserId == _currentUser.UserId) != null ? true : false
                }));
            if(interaction == null)
                throw new NotFoundException("Not found interaction for current user");

            return new GetInteractionQueryResult(
                MangaId : interaction.MangaId,
                RatingId: interaction.RatingId,
                Rating: interaction.Rating,
                Following: interaction.Following
                );
        }
    }
}
