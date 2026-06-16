using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.DTOs
{
    public class UpdateUserResponseDto
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }    
        public string? AvatarUrl { get; set; }
        public string? BackgroundUrl { get; set; }  
    }
}
