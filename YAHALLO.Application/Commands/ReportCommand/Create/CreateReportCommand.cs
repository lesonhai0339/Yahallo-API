using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.ReportEnums;

namespace YAHALLO.Application.Commands.ReportCommand.Create
{
    public class CreateReportCommand: IRequest<ResponseResult<string>>
    {
        public string? Title { get;set; }
        public string? Description { get;set; }
        public string? Content { get; set; }
        public string? Target { get;set; }
        public ReportEnumType Type { get; set; }
        public ICollection<IFormFile>? Media { get; set; }
    }
}
