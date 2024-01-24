using BookStore.Api.Features.Books;

namespace BookStore.Api.Features.BookCategories;

public class BookCategory
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public List<Book> Books { get; } = [];
}
