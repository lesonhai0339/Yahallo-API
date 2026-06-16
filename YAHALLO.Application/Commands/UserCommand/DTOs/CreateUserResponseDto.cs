using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.UserCommand.DTOs
{
    public class CreateUserResponseDto
    {
        public string? Message { get; set; }    
        public string? AvatarUrl { get; set; }  
        public string? BackgroundUrl { get; set; }  
    }
}
