//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.BookmarkCommand.Create
{
    public class CreateBookmarkCommandHandler : IRequestHandler<CreateBookmarkCommand, string>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateBookmarkCommandHandler(IBookmarkRepository bookmarkRepository, ICurrentUserService currentUser)
        {
            _bookmarkRepository = bookmarkRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(CreateBookmarkCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;
            if (string.IsNullOrEmpty(userId))
                throw new UnAuthorizeException("Bạn cần đăng nhập để tạo dấu trang");

            var bookmark = new BookmarkEntity
            {
                Name = request.Name,
                Descriptions = request.Descriptions,
                UserId = userId,
                MangaId = string.IsNullOrEmpty(request.MangaId) ? null : request.MangaId,
                ChapterId = string.IsNullOrEmpty(request.ChapterId) ? null : request.ChapterId,
                BlogId = string.IsNullOrEmpty(request.BlogId) ? null : request.BlogId,
                CreateDate = DateTime.UtcNow,
                IdUserCreate = userId,
            };

            _bookmarkRepository.Add(bookmark);
            var result = await _bookmarkRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0 ? bookmark.Id : string.Empty;
        }
    }
}
