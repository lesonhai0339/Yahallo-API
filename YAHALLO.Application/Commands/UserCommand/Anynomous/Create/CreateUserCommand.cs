using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Create
{
    public class CreateUserCommand : IRequest<string>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public IFormFile? Avatar { get; set; }   
    }
}
