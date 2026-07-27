using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.DTOs;

namespace YAHALLO.Application.Commands.ChapterImageCommand.Create
{
    public class CreateChapterImageCommand: IRequest<CreateChapterImageResult>
    {
        public string ChapterId { get; set; } = null!;
        public List<FileUploadInfo> FileUploadInfo { get; set; } = new List<FileUploadInfo>();

    }
    public record CreateChapterImageResult
    {
        public List<CreateChapterImageItem> Data { get; set; } = new List<CreateChapterImageItem>();
    }
    public record CreateChapterImageItem
    {
        public string Id { get; set; } = null!; 
        public decimal Index { get; set; }  
        public string UploadUrl { get; set; } = null!;
        public string ChapterId { get; set; } = null!;
    }
}
