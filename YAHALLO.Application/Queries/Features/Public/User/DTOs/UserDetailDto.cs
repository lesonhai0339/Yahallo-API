using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.UserEnums;

namespace YAHALLO.Application.Queries.Features.Public.User.DTOs
{
    public class UserDetailDto
    {
        public string Id { get; set; } = string.Empty;

        public string? DisplayName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }
        public bool? EmailConfirmed { get; set; }   

        public string? Avatar { get; set; }

        public string? Background { get; set; }

        public UserLevel? Level { get; set; }

        public UserStatus? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateTime { get; set; }
    }
}
