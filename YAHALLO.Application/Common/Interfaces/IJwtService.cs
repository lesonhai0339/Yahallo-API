using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(string ID, string roles);
    }
}
