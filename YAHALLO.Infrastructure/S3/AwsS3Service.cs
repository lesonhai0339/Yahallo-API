using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.Repositories.Storage;
using YAHALLO.Domain.S3;

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
        public async Task<IEnumerable<S3Response>> CreateSignedURL(IEnumerable<T> files)
        {
            return await Task.WhenAll(files.Select(async fileInfo => await CreateSignedURL(fileInfo)));
        }
        public async Task<bool> DeleteFile(T fileInfo, string url)
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _options.BucketName,
                Key = fileInfo.GetKeyFromUrl(url),
            };
            var response = await _s3Client.DeleteObjectAsync(request);
            return response.HttpStatusCode == System.Net.HttpStatusCode.NoContent;
        }
        public async Task<S3Response> CreateSignedURL(T fileInfo)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _options.BucketName,
                Key = fileInfo.GenerateKey(),
                Expires = DateTime.UtcNow.AddMinutes(15),
                Verb = HttpVerb.PUT,
                ContentType = fileInfo.ContentType,      
            };
            var url =  await _s3Client.GetPreSignedURLAsync(request);
            return new S3Response
            {
                Url = url,
                CloundFrontDomain = _options.CloundFrontDomain,
            };
        }
        public async Task<S3Response> GetObjectURL(T fileInfo)
        {
            var request = new GetObjectMetadataRequest
            {
                BucketName = _options.BucketName,
                Key = fileInfo.Key,
            };
            var obj =  await _s3Client.GetObjectMetadataAsync(request);
            return new S3Response
            {
                Object = obj,
                CloundFrontDomain = _options.CloundFrontDomain,
            };
        }
    }
}
