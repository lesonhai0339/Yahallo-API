﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Commands.BlogCommand.Update
{
    public class UpdateBlogCommandValidator: AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator() { }
    }
}
