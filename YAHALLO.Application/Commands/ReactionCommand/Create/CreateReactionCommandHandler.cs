using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.ReactionCommand.Create
{
    public class CreateReactionCommandHandler : IRequestHandler<CreateReactionCommand, bool>
    {
        private readonly IReactionRepository _reactionRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateReactionCommandHandler(IReactionRepository reactionRepository, ICurrentUserService currentUser)
        {
            _reactionRepository = reactionRepository;   
            _currentUser = currentUser; 
        }
        public Task<bool> Handle(CreateReactionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
