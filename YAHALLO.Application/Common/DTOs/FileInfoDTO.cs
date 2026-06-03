using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.DTOs
{
    public class FileInfoDTO
    {
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty; 
        public long FileSize { get; set; }  
    }
}
