﻿using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;
using System.Security.Claims;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Common;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal? _claimsPrincipal;
        private readonly IAuthorizationService _authorizationService;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
        {
            _claimsPrincipal = httpContextAccessor?.HttpContext?.User;
            _authorizationService = authorizationService;
        }

        public string? UserId => _claimsPrincipal?.FindFirst(JwtClaimTypes.Subject)?.Value;
        public string? Level => _claimsPrincipal?.FindFirst("UserLevel")?.Value;
        public async Task<bool> AuthorizeAsync(string policy)
        {
            if (_claimsPrincipal == null) return false;
            return (await _authorizationService.AuthorizeAsync(_claimsPrincipal, policy)).Succeeded;
        }

        public async Task<bool> IsInRoleAsync(string role)
        {
            return await Task.FromResult(_claimsPrincipal?.IsInRole(role) ?? false);
        }
        public bool CheckLevel(UserLevel level)
        {
            if(Level == null) return false;
            UserLevel curLevel= (UserLevel) Enum.Parse(typeof(UserLevel), Level, true); 
            if(curLevel < level)
            {
                return false;
            }
            return true;
        }
    }
}
