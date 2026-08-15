//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Authorization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Application.Common.Pagination.Pagination;
using YAHALLO.Domain.Common.Helper;
using YAHALLO.Domain.Entities;
using YAHALLO.Domain.Exceptions;
using YAHALLO.Domain.Repositories;

namespace YAHALLO.Application.Queries.Features.Public.Report.Filter
{
    public class FilterReportQueryHandler : IRequestHandler<FilterReportQuery, PagedResult<ReportDto>>
    {
        private readonly IReportRepository _reportRepository;
        private readonly ICurrentUserService _currentUser;
        public FilterReportQueryHandler(IReportRepository reportRepository, ICurrentUserService currentUser)
        {
            _reportRepository = reportRepository;
            _currentUser = currentUser;
        }

        public async Task<PagedResult<ReportDto>> Handle(FilterReportQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUser.UserId;
            if (string.IsNullOrEmpty(userId))
                throw new UnAuthorizeException("Bạn cần đăng nhập để xem báo cáo");

            // Báo cáo chứa nội dung tố cáo người khác — người thường CHỈ được xem
            // báo cáo do chính mình gửi, mọi bộ lọc theo người gửi đều bị ép về mình.
            var isStaff = await _currentUser.AuthorizeAsync(Policies.ModOrAdmin);

            var reports = await _reportRepository.FindAllSelectAsync(
                request.PageNo,
                request.PageSize,
                selector: q =>
                    OrderHelper.ApplyOrder(ApplyFilter(q, request, isStaff, userId), x => x.CreateDate, request.ReverseSort)
                        .Select(x => new ReportDto
                        {
                            Id = x.Id,
                            Title = x.Title,
                            Type = x.Type,
                            Target = x.Target,
                            Description = x.Description,
                            Content = x.Content,
                            IdUserReport = x.IdUserReport,
                            UserName = x.User == null ? null : x.User.DisplayName,
                            UserAvatar = x.User == null ? null : x.User.AvatarThumbnail,
                            CreateDate = x.CreateDate,
                        }),
                cancellationToken);

            return reports.MapToPagedResult(x => x);
        }

        private IQueryable<ReportEntity> ApplyFilter(
            IQueryable<ReportEntity> query, FilterReportQuery request, bool isStaff, string userId)
        {
            if (!isStaff)
            {
                query = query.Where(x => x.IdUserReport == userId);
            }
            else if (!string.IsNullOrEmpty(request.IdUserReport))
            {
                query = query.Where(x => x.IdUserReport == request.IdUserReport);
            }

            if (request.Type.HasValue) query = query.Where(x => x.Type == request.Type.Value);

            if (!string.IsNullOrEmpty(request.Target)) query = query.Where(x => x.Target == request.Target);

            if (!string.IsNullOrEmpty(request.Title)) query = query.Where(x => x.Title.Contains(request.Title));

            return query;
        }
    }
}
