using FluentValidation;
using FluentValidation.Results;
using MediatR;
using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request is IPaginatedQuery p)
            {
                var pagingFailures = new List<ValidationFailure>();
                if (p.PageNo < 1)
                    pagingFailures.Add(new(nameof(p.PageNo), "PageNo phải lớn hơn hoặc bằng 1"));
                if (p.PageSize is < 1 or > 100)
                    pagingFailures.Add(new(nameof(p.PageSize), "PageSize phải trong khoảng 1–100"));
                if (pagingFailures.Count != 0)
                    throw new ValidationException(pagingFailures);
            }
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
