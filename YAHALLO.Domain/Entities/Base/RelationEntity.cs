using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Entities.Base
{
    public class RelationEntity
    {
        public DateTime? CreateDate { get; set; }
        public string? IdUserCreate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? IdUserUpdate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string? IdUserDelete { get; set; }
    }
}
