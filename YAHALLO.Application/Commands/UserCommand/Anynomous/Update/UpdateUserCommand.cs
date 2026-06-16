using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Commands.UserCommand.DTOs;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserResponseDto>
    {
        public string Id { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string? PhoneNumber { get; set; }

        public IFormFile? Avatar { get; set; }
        public IFormFile? Background { get; set; }  
    }
}
