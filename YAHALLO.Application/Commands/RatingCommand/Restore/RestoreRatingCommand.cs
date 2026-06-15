using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Restore
{
    public class RestoreRatingCommand: IRequest<bool>
    {
        public string TargetId { get; set; } = string.Empty;
        public RatingEnum RatingTo { get; set; }    
        public string UserId { get; set; } = string.Empty;
    }
}
