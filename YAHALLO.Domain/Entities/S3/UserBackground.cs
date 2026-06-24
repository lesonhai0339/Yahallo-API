using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Entities.S3
{
    public class UserBackground: S3FileBase
    {
        public override string GenerateKey()
        {
            return $"public/user_backgrounds/{Id}/{FileName}";
        }
        public override string Prefix => "public/user_backgrounds";

    }
}
