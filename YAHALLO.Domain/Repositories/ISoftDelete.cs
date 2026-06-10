using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Repositories
{
    public interface ISoftDelete 
    {
        string? IdUserDelete { get; }
        DateTime? DeleteDate { get; }
    }
}
