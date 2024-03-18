using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Commands.UserCommand.Create
{
    public class CreateUserCommand : IRequest<string>
    {
        public CreateUserCommand(
            string firstname,
            string lastname,
            string email,
            string? phonenumber,
            string username,
            string password
            )
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            PhoneNumber = phonenumber;
            UserName = username;
            Password = password;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
