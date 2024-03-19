using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Commands.UserCommand.Update
{
    public class UpdateUserCommand: IRequest<string>
    {
        public UpdateUserCommand() { }
        public UpdateUserCommand(
            string id,
            string? displayname,
            string? phonenumber,
            IFormFile? avatar)
        {
            Id = id;
            DisplayName = displayname;
            PhoneNumber = phonenumber;
            Avatar = avatar;
        }
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? PhoneNumber { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
