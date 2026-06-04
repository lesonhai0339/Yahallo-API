using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Application.Queries.ChapterQuery.GetAllImage;
using YAHALLO.Application.Queries.ChapterQuery.GetAllPagination;

namespace YAHALLO.Application.Queries.ChapterQuery.GetImage
{
    public class GetImageValidator : AbstractValidator<GetImageQuery>
    {
        public GetImageValidator()
        {
            RuleFor(x => x.ChapterId).NotNull().NotEmpty().WithMessage("ChapterId Size không được bỏ trống");
        }
    }
}
