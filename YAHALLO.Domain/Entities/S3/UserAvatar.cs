using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.FileUpload;

namespace YAHALLO.Domain.Entities.S3
{
    public class UserAvatar: S3FileBase
    {
        public override string GenerateKey() => $"public/user_avatars/{Id}/{FileName}";
        public override string Prefix => "public/user_avatars";

    }
}
