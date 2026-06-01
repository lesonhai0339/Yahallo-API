using Amazon.Runtime.Internal.Util;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Repositories.Storage;

namespace YAHALLO.Infrastructure.S3
{
    public class AwsS3Service<T>: IStorageService<T> where T : S3FileBase
    {
        private readonly ILogger<AwsS3Service<T>> _logger;
        private readonly IAmazonS3 _s3Client;
        private readonly AwsS3Options _options;
        public AwsS3Service(IOptions<AwsS3Options> options, IAmazonS3 s3Client, ILogger<AwsS3Service<T>> logger)
        {
            _options = options.Value;

            _s3Client = s3Client;
            _logger = logger;
        }   
        public async Task<string> CreateSignedURL(T fileInfo)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _options.BucketName,
                Key = fileInfo.GenerateKey(),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Verb = HttpVerb.PUT
            };
            return await _s3Client.GetPreSignedURLAsync(request);
        }
        public async Task<object> GetObjectURL(T fileInfo)
        {
            var request = new GetObjectMetadataRequest
            {
                BucketName = _options.BucketName,
                Key = fileInfo.Key,
            };
            return await _s3Client.GetObjectMetadataAsync(request);
        }
    }
}
