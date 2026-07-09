using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Domain.Entities.Base
{
    public class RelationEntity : ISoftDelete
    {
        public DateTime? CreateDate { get; set; }
        [MaxLength(450)]
        public string? IdUserCreate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(450)]
        public string? IdUserUpdate { get; set; }
        public DateTime? DeleteDate { get; set; }
        [MaxLength(450)]
        public string? IdUserDelete { get; set; }
    }
}
