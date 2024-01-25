namespace BookStore.Api.Features.Books.UpdateBookInfo;

public record UpdateBookInfoRequestDto(
    string Title,
    string Author)
{
    public UpdateBookInfoRequest AsRequest(Guid id) => new(id, Title, Author);
}
