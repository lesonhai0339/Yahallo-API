using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.ChapterCommand.Update
{
    public class UpdateChapterCommand: IRequest<ResponeResult>
    {
        public UpdateChapterCommand(
            string chapterid,
            string mangaid,
            string? title,
            int? index,
            ICollection<IFormFile> images,
            ICollection<string>? imageUrls)
        {
            ChapterId = chapterid;
            MangaId= mangaid;
            Title = title;
            Index = index;  
            Images = images;
            ImageUrls = imageUrls;
        }
        public required string ChapterId { get; set; }
        public required string MangaId { get; set; }
        public string? Title { get; set; }
        public int? Index { get; set; }
        public ICollection<IFormFile>? Images { get; set; }
        public ICollection<string>? ImageUrls { get; set; }
    }
}
