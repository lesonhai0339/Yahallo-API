using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common;
using YAHALLO.Domain.Enums;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Domain.Entities.Base
{
    public class BaseEntity : ISoftDelete
    {
        [Key]
        [MaxLength(450)]
        public string Id { get; set; } = SequentialGuid.NewId();
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [MaxLength(450)]
        public string? IdUserCreate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(450)]
        public string? IdUserUpdate { get; set; }
        public DateTime? DeleteDate { get; set; }
        [MaxLength(450)]
        public string? IdUserDelete { get; set; }

        [NotMapped]
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

        ~BaseEntity()
        {
            Dispose(isDisposing: false);
        }
        #endregion Dispose
    }
}
