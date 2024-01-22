using FluentResults;

namespace BookStore.Api.Common.Models;

public class ExceptionError : Error
{
    public ExceptionError(string message) : base(message)
    {
    }
}
