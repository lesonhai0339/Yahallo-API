using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.UserSettingsQuery.GetById
{
    public class GetUserSettingsQueryHandler : IRequestHandler<GetUserSettingsQuery, UserSettingsDto>
    {
        private readonly IUserSettingsRepository _userSettingsRepository;
        private readonly ICurrentUserService _currentUser;
        public GetUserSettingsQueryHandler(IUserSettingsRepository userSettings,  ICurrentUserService currentUser)
        {
            _userSettingsRepository = userSettings; 
            _currentUser = currentUser; 
        }
        public async Task<UserSettingsDto> Handle(GetUserSettingsQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_currentUser.UserId))
                throw new UnAuthorizeException("Unknow user");

            var settings = await _userSettingsRepository.FindSelectAsync(x => x
                .Where(x => x.UserId == _currentUser.UserId)
                .Select(s => new UserSettingsDto
                {
                    Id = s.Id,
                    Language = s.Language,
                    Theme = s.Theme,
                    BgImageUrl = s.BgImageUrl,
                    BgBlur  = s.BgBlur,
                    BgOpacity = s.BgOpacity,
                    FontColor = s.FontColor,
                    FontWeight = s.FontWeight,
                    FontFamily = s.FontFamily,
                    FontSize = s.FontSize,
                    ListView = s.ListView,
                    MaxEntries = s.MaxEntries,
                    PageSize = s.PageSize,
                    ProgressReadMode = s.ProgressReadMode,
                    RetentionDays = s.RetentionDays 
                }),
                cancellationToken);
            if (settings == null)
                throw new NotFoundException($"Cannot find settings for current user");

            return settings;
        }
    }
}
