using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Restore
{
    public class RestoreMangaRatingCommand: IRequest<ResponeResult<string>>
    {
        public string MangaId { get;set; }
        public string UserId { get;set; }
        public RestoreMangaRatingCommand(string mangaId, string userId)
        {
            MangaId= mangaId;
            UserId= userId; 
        }
    }
}
