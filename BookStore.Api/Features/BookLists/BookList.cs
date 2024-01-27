namespace BookStore.Api.Features.BookLists;

public class BookList
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Guid UserId { get; set; }
    public List<BookListItem> Items { get; } = [];
}
