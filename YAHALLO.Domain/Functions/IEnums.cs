using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Functions
{
    public interface IEnums
    {
        public object? GetClassFromEnum(Enum enumValue);
    }
}
