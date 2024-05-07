using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.ChapterCommand.Create
{
    public class CreateChapterCommand: IRequest<ResponeResult<string>>
    {
        public CreateChapterCommand() { }
        public CreateChapterCommand(
            string? title,
            int index,
            string mangaid)
        {
            Title = title;
            Index = index;
            MangaId = mangaid;
        }
        public string? Title { get; set; }
        public required int Index { get; set; }
        public required string MangaId { get; set; }
        public ICollection<IFormFile>? Images { get; set; }
        public ICollection<string>? ImageUrls { get;set; }  
    }
}
