using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.MangaRatingCommand.Delete
{
    public class DeleteMangaRatingCommand: IRequest<ResponseResult<string>>
    {
        public string Mangaid { get; set; }
        public string UserId { get; set; }
        public DeleteMangaRatingCommand(string mangaid, string userId)
        {
            Mangaid = mangaid;
            UserId = userId;
        }
    }
}
