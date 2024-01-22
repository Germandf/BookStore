namespace BookStore.Api.Features.Books;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public string? ISBN { get; set; }
    public required decimal Price { get; set; }
    public int Stock { get; set; }
}
