using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.ReportCommand.Create
{
    public class CreateReportCommandValidator: AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator() 
        {
            RuleFor(x => x)
                .Must(CheckValid)
                .WithMessage("Không được bỏ trống tất cả tham số");
        }
        public bool CheckValid(CreateReportCommand command)
        {
            if(command.Title == null && command.Description == null && command.Content == null && command.Media == null)
            {
                return false;
            }
            return true;
        }
    }
}
