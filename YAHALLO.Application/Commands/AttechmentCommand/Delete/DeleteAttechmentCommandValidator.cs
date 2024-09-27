using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.AttechmentCommand.Delete
{
    public class DeleteAttechmentCommandValidator: AbstractValidator<DeleteAttechmentCommand>
    {
        public DeleteAttechmentCommandValidator() { }
    }
}
