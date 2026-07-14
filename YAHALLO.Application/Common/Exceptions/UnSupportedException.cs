using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Exceptions
{
    public class UnSupportedException: Exception
    {
        public UnSupportedException(string message) : base(message) { }
        public UnSupportedException(string message, Exception exception) : base(message, exception) { }     
    }
}
