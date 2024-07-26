using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;
using YAHALLO.Domain.Enums.MangaEnums;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Domain.Entities.Reference
{
    public class AttechmentEntity: BaseEntity
    {
        public string? Description { get;set; }
        public CommentMediaType? MediaType { get; set; } = null!;
        public string? Title { get;set; }    
        public string? Url1 { get;set; }
        public string? Url2 { get;set;}
        public string? Url3 { get;set;}

        public required string ParentId { get;set; }
        public virtual object Parent { get; set; } = null!;
    }
}
