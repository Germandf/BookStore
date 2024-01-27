namespace BookStore.Api.Common;

public static class Errors
{
    public static string EntityNotFound<T>(Guid id)
        => $"{nameof(T)} {id} not found.";
    
    public static string NewPriceBelowCurrent(decimal newPrice, decimal currentPrice)
        => $"New price ({newPrice}) cannot be lower than the current price ({currentPrice})";

    public static string BookUpdateWithISBN(string iSBN)
        => $"Book info cannot be updated if the book has an ISBN ({iSBN})";
}
