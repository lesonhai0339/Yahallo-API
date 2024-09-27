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
        /// <summary>
        /// Get current UserId
        /// </summary>
        string? UserId { get; }
        /// <summary>
        /// Get current User Level (1-9)
        /// </summary>
        string? Level {get;}
        /// <summary>
        /// Check current User has this tole (Admin, User, Mod, Upload)
        /// </summary>
        /// <param name="role">string role</param>
        /// <returns></returns>
        Task<bool> IsInRoleAsync(string role);
        Task<bool> AuthorizeAsync(string policy);
        /// <summary>
        /// Check Current User have this level (1-9)
        /// </summary>
        /// <param name="level">enum</param>
        /// <returns></returns>
        bool CheckLevel(UserLevel level);
    }
}
