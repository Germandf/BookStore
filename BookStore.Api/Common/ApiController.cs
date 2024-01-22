using BookStore.Api.Common.Models;
using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookStore.Api.Common;

[ApiController]
[Route("api/", Name = "Api")]
public abstract class ApiControllerBase : ControllerBase
{
    protected ISender _mediator;
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    protected ApiControllerBase(ISender mediator, ProblemDetailsFactory problemDetailsFactory)
    {
        _mediator = mediator;
        _problemDetailsFactory = problemDetailsFactory;
    }

    protected IActionResult ToHttpResponse<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            if (typeof(T) == typeof(Success))
                return new OkResult();

            return new OkObjectResult(result.Value);
        }

        var problemDetails = result.Errors.First() is ValidationError ?
            CreateValidationProblemDetails(result.Errors) : 
            CreateProblemDetails(result.Errors.First());

        return new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }

    private ValidationProblemDetails CreateValidationProblemDetails(List<IError> errors)
    {
        var modelState = new ModelStateDictionary();

        foreach (var error in errors)
        {
            if (error is ValidationError validationError)
                modelState.AddModelError(validationError.PropertyName, error.Message);
        }

        return _problemDetailsFactory.CreateValidationProblemDetails(
            HttpContext,
            modelState, 
            statusCode: StatusCodes.Status400BadRequest);
    }

    private ProblemDetails CreateProblemDetails(IError error)
    {
        var exceptionError = error as ExceptionError;
        var statusCode = exceptionError is not null ? StatusCodes.Status500InternalServerError : StatusCodes.Status409Conflict;
        var title = exceptionError is not null ? null : error.Message;

        return _problemDetailsFactory.CreateProblemDetails(
            HttpContext, 
            statusCode: statusCode, 
            title: title);
    }
}
