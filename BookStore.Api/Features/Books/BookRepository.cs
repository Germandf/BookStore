using BookStore.Api.Persistence;

namespace BookStore.Api.Features.Books;

public interface IBookRepository
{
    void Add(Book book);
}

public class BookRepository(BookStoreDbContext dbContext) : IBookRepository
{
    public void Add(Book book) => dbContext.Add(book);
}
