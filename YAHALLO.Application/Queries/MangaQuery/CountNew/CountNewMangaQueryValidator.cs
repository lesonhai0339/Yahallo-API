using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Queries.MangaQuery.CountNew
{
    public class CountNewMangaQueryValidator: AbstractValidator<CountNewMangaQuery>
    {
        public CountNewMangaQueryValidator()
        {
            RuleFor(x => x.PageNo).GreaterThan(0).WithMessage("Page number must be greater than 0.");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Page size must be greater than 0.");   

            RuleFor(x => x.To).GreaterThan(x => x.From).WithMessage("The 'To' date must be greater than the 'From' date."); 
            RuleFor(x => x).Must(x => 
            x.CountBy != MangaCountBy.Day || (x.To - x.From).Days <= 366).WithMessage("Time too long for filter by day");   
        }
    }
}
