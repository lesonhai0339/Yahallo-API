using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.DTOs
{
    public class FileUploadInfo
    {
        //source
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public int Width { get; set; }
        public int Height { get; set; }
        public long Length { get; set; }

        //resize
        public int ResizeWidth { get; set;  }
        public int ResizeHeight { get; set; }
        public long ResizeLength { get; set; }

    }
}
