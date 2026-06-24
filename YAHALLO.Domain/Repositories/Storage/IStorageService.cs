using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.S3;
using YAHALLO.Domain.S3;

namespace YAHALLO.Domain.Repositories.Storage
{
    public interface IStorageService<T> where T : S3FileBase
    {
        Task<S3Response> CreateSignedURL(T fileInfo);
        Task<IEnumerable<S3Response>> CreateSignedURL(IEnumerable<T> files);
        Task<bool> DeleteFile(T fileInfo, string url);

        /// <summary>
        /// Return object GetObjectMetadataResponse(AWS object)
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        Task<S3Response> GetObjectURL(T fileInfo);
    }
}
