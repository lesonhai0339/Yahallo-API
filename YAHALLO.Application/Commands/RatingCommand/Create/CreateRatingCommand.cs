using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Create
{
    public class CreateRatingCommand: IRequest<string>
    {
        public string TargetId { get; set; }  = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public RatingEnum RatingTo { get; set; }
        public double Rating { get; set; }
    }
}
