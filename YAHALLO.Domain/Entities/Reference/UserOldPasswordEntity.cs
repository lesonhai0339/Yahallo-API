using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities.Reference
{
    public class UserOldPasswordEntity: RelationEntity
    {
        public UserOldPasswordEntity() { }
        public UserOldPasswordEntity(UserEntity userEntity)
        {
            UserId = userEntity.Id;
            UserEntity = userEntity;
        }
        public UserOldPasswordEntity(string userId, UserEntity userEntity, string? oldPasswords)
        {
            UserId = userId;
            UserEntity = userEntity;
            OldPasswords = oldPasswords;
        }

        public string? UserId { get; set; }
        public virtual UserEntity? UserEntity { get; set; }

        public string? OldPasswords { get; set; }
        public void AddNew(string newpsd)
        {
            OldPasswords += "{" + newpsd + "}";
        }
        public List<string> OldPasswordList()
        {
            if(OldPasswords != null)
            {
                var array = OldPasswords.Split("}{").ToList();
                return array;
            }
            return new List<string>() { };
        }

    }
}
