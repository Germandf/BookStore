using BookStore.Api.Common.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Common;

public static class ResultExtensions
{
    public static IActionResult ToHttpResponse<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            if (typeof(T) == typeof(Success))
            {
                return new OkResult();
            }

            return new OkObjectResult(result.Value);
        }

        return result.Errors.First() switch
        {
            ValidationError _ => new BadRequestObjectResult(
                new ErrorResponse { ErrorType = ErrorResponseType.Validation, Errors = result.ToErrorList() }),
            ExceptionError _ => new BadRequestObjectResult(
                new ErrorResponse { ErrorType = ErrorResponseType.Exception, Errors = new() { 
                    "Hubo un error al realizar la operación solicitada, intentá de nuevo más tarde o contactá con nosotros." } }),
            _ => new BadRequestObjectResult(
                new ErrorResponse { ErrorType = ErrorResponseType.Business, Errors = result.ToErrorList() }),
        };
    }

    private static List<string> ToErrorList<T>(this Result<T> result)
    {
        return result.Errors.Select(x => x.Message).ToList();
    }
}