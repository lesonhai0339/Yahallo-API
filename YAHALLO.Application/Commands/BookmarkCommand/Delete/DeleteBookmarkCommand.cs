//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BookmarkCommand.Delete
{
    public class DeleteBookmarkCommand : IRequest<bool>
    {
        public string Id { get; set; } = string.Empty;
    }
}
