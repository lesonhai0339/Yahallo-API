using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaCommand.UserMangaDailyRead
{
    public class UserMangaDailyReadNotification: INotification
    {
        public string UserId { get; init; } = null!;
        public string MangaId { get; init; } = null!;
        public string ChapterId { get; init; } = null!;  
    }
}
