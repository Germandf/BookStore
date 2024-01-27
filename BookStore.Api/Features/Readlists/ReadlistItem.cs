using BookStore.Api.Features.Books;

namespace BookStore.Api.Features.Readlists;

public class ReadlistItem
{
    public Guid Id { get; set; }
    public required Guid BookId { get; set; }
    public required Guid ReadlistId { get; set; }
    public required int Order { get; set; }
    public Book? Book { get; set; }
}
