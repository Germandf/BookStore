using BookStore.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Features.Books;

public interface IBookRepository
{
    void Add(Book book);
    Task<List<Book>> GetAll(CancellationToken ct = default);
    Task<Book?> GetById(Guid bookId, CancellationToken ct = default);
    void Remove(Book book);
    void Update(Book book);
}

public class BookRepository(BookStoreDbContext dbContext) : IBookRepository
{
    public void Add(Book book) => dbContext.Add(book);
    public Task<List<Book>> GetAll(CancellationToken ct = default) => dbContext.Books.ToListAsync(ct);
    public Task<Book?> GetById(Guid bookId, CancellationToken ct = default) => dbContext.Books.FindAsync(bookId, ct).AsTask();
    public void Remove(Book book) => dbContext.Remove(book);
    public void Update(Book book) => dbContext.Update(book);
}
