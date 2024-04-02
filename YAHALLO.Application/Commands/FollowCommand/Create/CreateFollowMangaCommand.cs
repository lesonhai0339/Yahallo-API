using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.FollowCommand.Create
{
    public class CreateFollowMangaCommand: IRequest<ResponeResult>
    {
        public CreateFollowMangaCommand(
            string userid,
            string mangaid)
        {
            UserId = userid;
            MangaId = mangaid;  
        }
        public string UserId { get; set; }
        public string MangaId { get; set; }
    }
}
