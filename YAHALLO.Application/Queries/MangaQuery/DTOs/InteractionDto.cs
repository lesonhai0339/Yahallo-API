using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaQuery.DTOs
{
    public class InteractionDto
    {
        public string MangaId { get; set; } = null!;
        public string? RatingId { get; set; }   
        public double? Rating { get; set; }
        public bool Following { get; set; } = false;
    }
}
