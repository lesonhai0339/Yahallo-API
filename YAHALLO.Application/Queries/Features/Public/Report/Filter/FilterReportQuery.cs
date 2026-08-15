//AI Generated
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Pagination;
using YAHALLO.Domain.Enums.ReportEnums;

namespace YAHALLO.Application.Queries.Features.Public.Report.Filter
{
    /// <summary>
    /// Hàng đợi báo cáo cho mod/admin. Trước đây chỉ có `report/create` nên báo cáo
    /// vào DB rồi nằm im, không có endpoint nào đọc ra.
    /// </summary>
    public class FilterReportQuery : IRequest<PagedResult<ReportDto>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

        public ReportEnumType? Type { get; set; }
        /// <summary>Lọc theo đúng đối tượng bị báo cáo (id truyện / chương / user / blog).</summary>
        public string? Target { get; set; }
        public string? Title { get; set; }
        /// <summary>Lọc theo người gửi báo cáo.</summary>
        public string? IdUserReport { get; set; }

        public bool ReverseSort { get; set; } = true;
    }
}
