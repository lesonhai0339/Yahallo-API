using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.MangaDaily;

namespace YAHALLO.Application.Commands.MangaCommand.MangaDaily
{
    public class UpdateMangaDailyNotification: INotification
    {
        public string? MangaId { get; set; } = null!;
        public MangaDailyType Type { get; set; }
        public bool IsDelete { get; set; } = false;
    }
}
