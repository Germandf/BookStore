using BookStore.Api.Common.Models;
using FluentResults;
using FluentValidation;
using MediatR;

namespace BookStore.Api.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .ToList();

        if (validationFailures.Any())
        {
            var response = new TResponse();

            foreach (var failure in validationFailures)
                response.Reasons.Add(new ValidationError(failure.PropertyName, failure.ErrorMessage));

            return response;
        }

        return await next();
    }
}
