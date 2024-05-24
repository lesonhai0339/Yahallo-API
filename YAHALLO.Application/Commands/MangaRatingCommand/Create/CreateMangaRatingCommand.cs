using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Create
{
    public class CreateMangaRatingCommand: IRequest<ResponeResult<string>>
    {
        public string MangaId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public CreateMangaRatingCommand(string mangaId, string userId, int rating)
        {
            MangaId = mangaId;
            UserId = userId;
            Rating = rating;
        }
    }
}
