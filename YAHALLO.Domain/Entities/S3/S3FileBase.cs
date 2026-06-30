using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.FileUpload;

namespace YAHALLO.Domain.Entities.S3
{
    public class S3FileBase
    {
        public required string Id { get; set; } //UserId
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty; 
        public long FileSize { get; set; }
        public int Width { get; set;  }
        public int Height { get; set; } 
        public string Etag { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public FileUploadStatus Status { get; set; }
        public virtual string GenerateKey() => $"{Id}/{FileName}";
        public virtual string Prefix => "public";
        public virtual string GetKeyFromUrl(string url)
        {
            var uri = new Uri(url);

            return uri.AbsolutePath.TrimStart('/');
        }
        public virtual string Suffix
        {
            get
            {
                var key = GenerateKey();
                return key.StartsWith(Prefix)
                    ? key.Substring(Prefix.Length).TrimStart('/')
                    : key;
            }
        }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public string? IdUserCreate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? IdUserUpdate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string? IdUserDelete { get; set; }

        private bool IsDisposed { get; set; }

        #region Dispose
        public void Dispose()
        {
            Dispose(isDisposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!IsDisposed)
            {
                if (isDisposing)
                {
                    DisposeUnmanagedResources();
                }

                IsDisposed = true;
            }
        }

        protected virtual void DisposeUnmanagedResources()
        {
        }

        ~S3FileBase()
        {
            Dispose(isDisposing: false);
        }
        #endregion Dispose
    }
}
