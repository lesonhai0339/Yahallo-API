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

namespace YAHALLO.Application.Commands.MangaAssociateNameCommand.Create
{
    public class CreateMangaAssociateNameCommandHandler : IRequestHandler<CreateMangaAssociateNameCommand, int>
    {
        private readonly IMangaAssociateNameRepository _associateNameRepository;
        private readonly IMangaRepository _mangaRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateMangaAssociateNameCommandHandler(
            IMangaAssociateNameRepository associateNameRepository,
            IMangaRepository mangaRepository,
            ICurrentUserService currentUser)
        {
            _associateNameRepository = associateNameRepository;
            _mangaRepository = mangaRepository;
            _currentUser = currentUser;
        }

        public async Task<int> Handle(CreateMangaAssociateNameCommand request, CancellationToken cancellationToken)
        {
            var manga = await _mangaRepository.FindAsync(x => x.Id == request.MangaId, cancellationToken);
            if (manga is null)
                throw new NotFoundException($"Không tìm thấy truyện với id {request.MangaId}");

            // Bỏ tên trùng ngay trong danh sách gửi lên, và tên đã có sẵn trong DB.
            var existed = await _associateNameRepository.FindAllSelectAsync(
                q => q.Where(x => x.MangaId == request.MangaId).Select(x => x.Name),
                cancellationToken);

            var incoming = request.Names
                .Select(n => n.Trim())
                .Where(n => !string.IsNullOrEmpty(n))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Where(n => !existed.Contains(n, StringComparer.OrdinalIgnoreCase))
                .ToList();

            if (incoming.Count == 0) return 0;

            foreach (var name in incoming)
            {
                _associateNameRepository.Add(new MangaAssociateNameEntity
                {
                    MangaId = request.MangaId,
                    Name = name,
                    CreateDate = DateTime.UtcNow,
                    IdUserCreate = _currentUser.UserId,
                });
            }

            await _associateNameRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return incoming.Count;
        }
    }
}
