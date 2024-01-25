namespace BookStore.Api.Features.Books.UpdateBookPrice;

public record UpdateBookPriceRequestDto(
    decimal Price)
{
    public UpdateBookPriceRequest AsRequest(Guid id) => new(id, Price);
}
