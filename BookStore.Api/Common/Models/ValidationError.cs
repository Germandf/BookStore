using FluentResults;

namespace BookStore.Api.Common.Models;

public class ValidationError : Error
{
    public string PropertyName { get; set; }

    public ValidationError(string propertyName, string message) : base(message)
    {
        PropertyName = propertyName;
    }
}
