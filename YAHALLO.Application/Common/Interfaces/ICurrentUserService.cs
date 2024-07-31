using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        string? Level {get;}
        Task<bool> IsInRoleAsync(string role);
        Task<bool> AuthorizeAsync(string policy);
        bool CheckLevel(UserLevel level);
    }
}
