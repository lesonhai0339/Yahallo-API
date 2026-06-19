using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.ReactionEnums;

namespace YAHALLO.Application.Commands.ReactionCommand.Create
{
    public class CreateReactionCommand: IRequest<bool>
    {
        public ReactionEnum? Reaction { get; set;  }

    }
}
