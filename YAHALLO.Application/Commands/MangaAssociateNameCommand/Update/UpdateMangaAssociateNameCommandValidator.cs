//AI Generated
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.MangaAssociateNameCommand.Update
{
    public class UpdateMangaAssociateNameCommandValidator : AbstractValidator<UpdateMangaAssociateNameCommand>
    {
        public UpdateMangaAssociateNameCommandValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id không được bỏ trống");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Tên khác không được bỏ trống");
        }
    }
}
