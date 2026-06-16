using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Exceptions
{
    public class UpdateFailedException: Exception
    {
        public UpdateFailedException(string message) : base(message) { }
        public UpdateFailedException(string message, Exception exception) : base(message, exception) { }    
    }
}
