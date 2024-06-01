using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.CommentCommand.Create
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, ResponseResult<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly ICommentRepository _commentRepository;
        public CreateCommentCommandHandler(IUserRepository userRepository, IMangaRepository mangaRepository, ICommentRepository commentRepository)
        {
            _userRepository = userRepository;
            _mangaRepository = mangaRepository;
            _commentRepository = commentRepository;
        }
        public async Task<ResponseResult<string>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
