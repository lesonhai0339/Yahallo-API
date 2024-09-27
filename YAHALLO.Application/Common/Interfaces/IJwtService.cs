using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.UserEnums;
namespace YAHALLO.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(string ID, List<string> roles);
        string CreateToken(string ID,UserLevel level, List<string> roles);
        string GenerateRefreshToken();
    }
}
