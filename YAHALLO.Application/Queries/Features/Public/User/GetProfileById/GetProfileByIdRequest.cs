using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.Features.Public.User.DTOs;

namespace YAHALLO.Application.Queries.Features.Public.User.GetProfileById
{
    public class GetProfileByIdRequest: IRequest<UserProfileDto>
    {
        public string Id { get; set; } = string.Empty; 
    }
}
