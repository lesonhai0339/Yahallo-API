using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;

namespace YAHALLO.Application.Commands.MangaCommand.Delete
{
    public class DeleteMangaCommand: IRequest<ResponeResult>
    {
        public string? Id { get; set; }
        public DeleteMangaCommand(
            string? id)
        {
            Id = id;    
        }
    }
}
