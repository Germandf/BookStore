using BookStore.Api.Features.Books;

namespace BookStore.Api.Features.BookLists;

public class BookListItem
{
    public Guid Id { get; set; }
    public required Guid BookId { get; set; }
    public required Guid BookListId { get; set; }
    public required int Order { get; set; }
    public Book? Book { get; set; }
}
