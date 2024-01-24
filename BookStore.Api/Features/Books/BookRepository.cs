using BookStore.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Features.Books;

public interface IBookRepository
{
    void Add(Book book);
    Task<Book?> Get(Guid bookId, CancellationToken ct = default);
    Task<List<Book>> GetAll(CancellationToken ct = default);
    void Remove(Book book);
    void Update(Book book);
}

public class BookRepository(BookStoreDbContext dbContext) : IBookRepository
{
    public void Add(Book book) => dbContext.Add(book);
    public Task<Book?> Get(Guid bookId, CancellationToken ct = default) => dbContext.Books.FindAsync(bookId, ct).AsTask();
    public Task<List<Book>> GetAll(CancellationToken ct = default) => dbContext.Books.ToListAsync(ct);
    public void Remove(Book book) => dbContext.Remove(book);
    public void Update(Book book) => dbContext.Update(book);
}
