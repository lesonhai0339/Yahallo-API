using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Interfaces
{
    public interface ICurrentContextService
    {
        string? CurrentHttpContext { get; }
        string? HttpContext { get; }
    }
}
