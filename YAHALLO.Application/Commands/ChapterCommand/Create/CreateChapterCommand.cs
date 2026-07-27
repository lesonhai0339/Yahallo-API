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
    public class CreateChapterCommand: IRequest<string>
    {
        public string? Title { get; set; }
        public required int Index { get; set; }
        public int SubIndex { get; set; }   
        public required string MangaId { get; set; }
    }
}
