using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaCommand.DTOs
{
    public class UpdateMangaResponseDto
    {
        public string? Message { get; set; }    
        public string? AvatarUrl { get; set; }  
        public string? BackgroundUrl { get; set; }  
    }
}
