using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Common
{
    internal static class SequentialGuid
    {
        internal static string NewId()
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            var bytes = new byte[16];

            // 48 bits timestamp
            bytes[0] = (byte)(timestamp >> 40);
            bytes[1] = (byte)(timestamp >> 32);
            bytes[2] = (byte)(timestamp >> 24);
            bytes[3] = (byte)(timestamp >> 16);
            bytes[4] = (byte)(timestamp >> 8);
            bytes[5] = (byte)(timestamp);

            // random bytes
            Random.Shared.NextBytes(bytes[6..]);

            // set version 7
            bytes[6] = (byte)((bytes[6] & 0x0F) | 0x70);
            // set variant
            bytes[8] = (byte)((bytes[8] & 0x3F) | 0x80);

            return new Guid(bytes).ToString("N");
        }
    }
}
