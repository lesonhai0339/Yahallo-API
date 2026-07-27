using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.S3
{
    public class S3Response
    {
        public string? Url { get; set; }
        public object? Object { get; set; } 
        public string CloundFrontDomain { get; set; } = string.Empty;   
        public int Width { get; set; }  
        public int Height { get; set; }
        public string ContentType { get; set; } = string.Empty;
    }
}
