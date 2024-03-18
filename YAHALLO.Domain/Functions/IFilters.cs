using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YAHALLO.Domain.Functions
{
    public interface IFilters
    {
       bool CheckString(string str1, string str2);
    }
}
