using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.UserCommand.DTOs;
using YAHALLO.Application.Common.DTOs;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Commands.UserCommand.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponseDto>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string CountryId { get; set; } = null!;

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public FileUploadInfo? Avatar { get; set; }   
        public FileUploadInfo? Background { get; set; }  
    }
}
