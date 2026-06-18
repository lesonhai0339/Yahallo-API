using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Helper
{
    public static class S3UrlHelper
    {
        public static string ToCloudFrontUrl(string? presignedOrS3Url, string? cloudFrontDomain)
        {
            if (string.IsNullOrEmpty(presignedOrS3Url) || string.IsNullOrEmpty(cloudFrontDomain))
                return string.Empty;
            var uri = new Uri(presignedOrS3Url);

            var key = uri.AbsolutePath.TrimStart('/');

            return $"https://{cloudFrontDomain.TrimEnd('/')}/{key}";
        }
    }
}
