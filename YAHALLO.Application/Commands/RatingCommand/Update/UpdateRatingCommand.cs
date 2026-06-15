using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Update
{
    public class UpdateRatingCommand: IRequest<bool>
    {
        public string RatingId { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
