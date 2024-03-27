using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Enums.CountryEnums;
using YAHALLO.Domain.Enums.MangaEnums;

namespace YAHALLO.Application.Commands.MangaCommand.Create
{
    public class CreateMangaCommandValidator: AbstractValidator<CreateMangaCommand>
    {
        public CreateMangaCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Tên không được để trống");
            RuleFor(x => x.Level).NotNull().NotEmpty().WithMessage("Level không được để trống");
            RuleFor(x => x.Status).NotNull().NotEmpty().WithMessage("Status không được để trống");
            RuleFor(x => x.Type).NotNull().NotEmpty().WithMessage("Type không được để trống");
            RuleFor(x => x.Countries).NotNull().NotEmpty().WithMessage("Quốc gia không được để trống");
            RuleFor(x => x.Season).NotNull().NotEmpty().WithMessage("Season không được để trống");
        }
    }
}
