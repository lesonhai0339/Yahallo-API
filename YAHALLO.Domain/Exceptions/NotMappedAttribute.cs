using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Exceptions
{
    public class NotMappedAttribute: Exception
    {
        public NotMappedAttribute(string message): base(message) { }
    }
}
