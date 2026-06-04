using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Exceptions
{
    public class ForbiddenAccessException: Exception
    {
        public ForbiddenAccessException(string message): base(message) { }
        public ForbiddenAccessException(string message, Exception innerException): base(message, innerException) { }    
    }
}
