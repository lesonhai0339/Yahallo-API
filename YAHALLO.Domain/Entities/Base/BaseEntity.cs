using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums;

namespace YAHALLO.Domain.Entities.Base
{
    public class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString("N");
        }
        [Key]
        public string Id { get; private set; }
        public DateTime? CreateDate { get; set; }
        public string? IdUserCreate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? IdUserUpdate { get; set; }
        public DateTime? DeleteDate { get; set; }
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
