using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.S3;

namespace YAHALLO.Domain.Repositories.Storage
{
    public interface IStorageService<T> where T : S3FileBase
    {
        Task<string> CreateSignedURL(T fileInfo);
        Task<IEnumerable<string>> CreateSignedURL(IEnumerable<T> files);

        /// <summary>
        /// Return object GetObjectMetadataResponse(AWS object)
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        Task<object> GetObjectURL(T fileInfo);
    }
}
