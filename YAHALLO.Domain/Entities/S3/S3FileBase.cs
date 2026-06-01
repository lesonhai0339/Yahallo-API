using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.FileUpload;

namespace YAHALLO.Domain.Entities.S3
{
    public class S3FileBase: BaseEntity
    {
        public required string FileName { get; set; }
        public required string ContentType { get; set; }
        public long FileSize { get; set; }
        public string Etag { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public FileUploadStatus Status { get; set; }
        public virtual string GenerateKey() => $"{Id}/{FileName}";
    }
}
