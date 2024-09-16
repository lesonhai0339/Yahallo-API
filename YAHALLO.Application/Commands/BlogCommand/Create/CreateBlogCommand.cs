using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Enums.Base;

namespace YAHALLO.Application.Commands.BlogCommand.Create
{
    public class CreateBlogCommand: IRequest<ResponseResult<string>>
    {
        public string? ParentId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }    
        public List<string> ThreadIds { get;set; }
        public List<string>? AttechmentIds { get;set;}
        public CreateBlogCommand(string? parentId, string? title, string? description, string? content, List<string> threadIds, List<string>? attechmentIds)
        {
            ParentId = parentId;
            Title = title;
            Description = description;
            Content = content;
            ThreadIds = threadIds;
            AttechmentIds = attechmentIds;
        }
    }
}
