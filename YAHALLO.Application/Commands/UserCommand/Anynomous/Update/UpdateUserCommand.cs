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

namespace YAHALLO.Application.Commands.UserCommand.Anynomous.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserResult>
    {
        public string? DisplayName { get; set; }
        public string? PhoneNumber { get; set; }
        public FileUploadInfo? Avatar { get; set; }
        public FileUploadInfo? Background { get; set; }  
    }
    public record UpdateUserResult(
        string Id, 
        string? DisplayName = null, 
        string? UploadAvatarUrl = null, 
        string? AccessAvatarUrl = null, 
        string? UpdaloadBackgroundUrl = null, 
        string? AccessBackgroundUrl = null);
    }
