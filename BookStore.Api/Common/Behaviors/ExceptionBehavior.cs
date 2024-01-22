using BookStore.Api.Common.Models;
using FluentResults;
using MediatR;

namespace BookStore.Api.Common.Behaviors;

public class ExceptionBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    private readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;

    public ExceptionBehavior(ILogger<ExceptionBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception catched in ExceptionBehavior");

            var response = new TResponse();
            response.Reasons.Add(new ExceptionError("Something went wrong, try again later or contact with us."));
            return response;
        }
    }
}
