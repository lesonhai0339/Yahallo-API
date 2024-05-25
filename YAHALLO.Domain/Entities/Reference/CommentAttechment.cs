using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities.Reference
{
    public class CommentAttechment: BaseEntity
    {
        public string? Description { get;set; }
        public required string MediaType { get;set; }
        public string? Title { get;set; }    
        public string? Url1 { get;set; }
        public string? Url2 { get;set;}
        public string? Url3 { get;set;}

        public required string ParentId { get;set; }
        public virtual CommentEntity Parent { get; set; }
    }
}
