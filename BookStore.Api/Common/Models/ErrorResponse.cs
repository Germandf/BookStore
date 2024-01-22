namespace BookStore.Api.Common.Models;

public class ErrorResponse
{
    public List<string> Errors { get; set; } = new();
    public ErrorResponseType ErrorType { get; set; }
}

public enum ErrorResponseType
{
    Authorization = 0,
    Validation = 1,
    Business = 2,
    Exception = 3,
}
