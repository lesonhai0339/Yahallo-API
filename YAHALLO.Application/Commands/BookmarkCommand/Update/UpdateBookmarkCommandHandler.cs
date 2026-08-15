//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Commands.BookmarkCommand.Update
{
    public class UpdateBookmarkCommandHandler : IRequestHandler<UpdateBookmarkCommand, bool>
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly ICurrentUserService _currentUser;
        public UpdateBookmarkCommandHandler(IBookmarkRepository bookmarkRepository, ICurrentUserService currentUser)
        {
            _bookmarkRepository = bookmarkRepository;
            _currentUser = currentUser;
        }

        public async Task<bool> Handle(UpdateBookmarkCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;
            if (string.IsNullOrEmpty(userId))
                throw new UnAuthorizeException("Bạn cần đăng nhập để thực hiện thao tác này");

            var bookmark = await _bookmarkRepository.FindAsync(x => x.Id == request.Id, cancellationToken);
            if (bookmark is null)
                throw new NotFoundException($"Không tìm thấy dấu trang với id {request.Id}");

            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);
            if (!isStaff && bookmark.UserId != userId)
                throw new UnAuthorizeException("Bạn không thể sửa dấu trang của người khác");

            bookmark.Name = request.Name;
            bookmark.Descriptions = request.Descriptions;
            bookmark.UpdateDate = DateTime.UtcNow;
            bookmark.IdUserUpdate = userId;
            _bookmarkRepository.Update(bookmark);

            var result = await _bookmarkRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
