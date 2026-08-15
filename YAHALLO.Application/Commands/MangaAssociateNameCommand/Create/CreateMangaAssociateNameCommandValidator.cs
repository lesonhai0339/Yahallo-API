//AI Generated
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaAssociateNameCommand.Create
{
    public class CreateMangaAssociateNameCommandValidator : AbstractValidator<CreateMangaAssociateNameCommand>
    {
        public CreateMangaAssociateNameCommandValidator()
        {
            RuleFor(x => x.MangaId).NotNull().NotEmpty().WithMessage("MangaId không được bỏ trống");
            RuleFor(x => x.Names).NotNull().NotEmpty().WithMessage("Phải có ít nhất một tên");
            RuleForEach(x => x.Names).NotEmpty().WithMessage("Tên khác không được bỏ trống");
        }
    }
}
