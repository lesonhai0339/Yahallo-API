using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaQuery.Analytics
{
    public class GetMangaAnalyticsQueryValidator: AbstractValidator<GetMangaAnalyticsQuery>
    {
        public GetMangaAnalyticsQueryValidator()
        {
            RuleFor(x =>x.MangaId).NotEmpty().WithMessage("MangaId không được để trống")
                .NotNull().WithMessage("MangaId không được null");

            RuleFor(x => x.To).GreaterThan(x =>  x.From).WithMessage("Ngày kết thúc phải lớn hơn ngày bắt đầu")
                .NotEmpty().WithMessage("Ngày kết thúc không được để trống")
                .NotNull().WithMessage("Ngày kết thúc không được null");

            RuleFor(x => x)
                .Must(x => x.FilterBy != Domain.Enums.MangaDaily.MangaDailyFilterBy.Day || (x.To - x.From).Days <= 366).WithMessage("Khi lọc theo ngày, khoảng thời gian không được vượt quá 1 năm");
        }
    }
}
