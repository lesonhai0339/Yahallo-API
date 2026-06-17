using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Exceptions
{
    public class ConflictException: Exception
    {
        public ConflictException(string message) : base(message) { }
        public ConflictException(string message, Exception ex): base(message, ex) { }   
    }
}
