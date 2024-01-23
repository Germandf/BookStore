using BookStore.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Features.Books;

public interface IBookRepository
{
    void Add(Book book);
    Task<List<Book>> GetBooks(CancellationToken ct = default);
}

public class BookRepository(BookStoreDbContext dbContext) : IBookRepository
{
    public void Add(Book book) => dbContext.Add(book);
    public Task<List<Book>> GetBooks(CancellationToken ct = default) => dbContext.Books.ToListAsync(ct);
}
