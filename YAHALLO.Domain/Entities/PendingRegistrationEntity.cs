using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Entities.Base;

namespace YAHALLO.Domain.Entities
{
    public class PendingRegistrationEntity: BaseEntity
    {
        //register field
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? CountryId { get; set;  }
        public string UserName { get; set; } = null!;
        public string  HashedPassword { get; set; } = null!;


        // Why not create
        public string? MatchReason { get; set; }     
        public string? MatchedSource { get; set; }

        // Why review
        public ReviewStatus Status { get; set; } = ReviewStatus.Pending;
        public string? ReviewedById { get; set; }    
        public DateTime? ReviewedAt { get; set; }
        public string? ReviewNote { get; set; }
    }
    public enum ReviewStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2
    }
}
