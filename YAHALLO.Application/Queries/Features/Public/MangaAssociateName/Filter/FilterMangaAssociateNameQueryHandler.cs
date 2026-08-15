//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.MangaAssociateName.Filter
{
    public class FilterMangaAssociateNameQueryHandler
        : IRequestHandler<FilterMangaAssociateNameQuery, PagedResult<MangaAssociateNameDto>>
    {
        private readonly IMangaAssociateNameRepository _associateNameRepository;
        public FilterMangaAssociateNameQueryHandler(IMangaAssociateNameRepository associateNameRepository)
        {
            _associateNameRepository = associateNameRepository;
        }

        public async Task<PagedResult<MangaAssociateNameDto>> Handle(
            FilterMangaAssociateNameQuery request, CancellationToken cancellationToken)
        {
            var names = await _associateNameRepository.FindAllSelectAsync(
                request.PageNo,
                request.PageSize,
                selector: q =>
                    OrderHelper.ApplyOrder(ApplyFilter(q, request), x => x.Name, request.ReverseSort)
                        .Select(x => new MangaAssociateNameDto
                        {
                            Id = x.Id,
                            Name = x.Name,
                            MangaId = x.MangaId,
                        }),
                cancellationToken);

            return names.MapToPagedResult(x => x);
        }

        private IQueryable<MangaAssociateNameEntity> ApplyFilter(
            IQueryable<MangaAssociateNameEntity> query, FilterMangaAssociateNameQuery request)
        {
            if (!string.IsNullOrEmpty(request.MangaId)) query = query.Where(x => x.MangaId == request.MangaId);

            if (!string.IsNullOrEmpty(request.Name)) query = query.Where(x => x.Name.Contains(request.Name));

            return query;
        }
    }
}
