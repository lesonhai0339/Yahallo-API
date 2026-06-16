using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class UserTokenEntity: RelationEntity
    {
        public string Id { get; set; } = null!;
        public virtual UserEntity UserEntity { get; set; } = null!;
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public string? ExpiredRefreshToken { get;set; }
        public void SetExpiredTime(DateTime date)
        {
            this.ExpiredRefreshToken= date.ToShortDateString();
        }
    }
}
