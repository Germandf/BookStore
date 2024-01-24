using BookStore.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Features.Books;

public interface IBookRepository
{
    void Add(Book book);
    Task<Book?> GetBook(Guid bookId);
    Task<List<Book>> GetBooks(CancellationToken ct = default);
    void Update(Book book);
}

public class BookRepository(BookStoreDbContext dbContext) : IBookRepository
{
    public void Add(Book book) => dbContext.Add(book);
    public Task<Book?> GetBook(Guid bookId) => dbContext.Books.FindAsync(bookId).AsTask();
    public Task<List<Book>> GetBooks(CancellationToken ct = default) => dbContext.Books.ToListAsync(ct);
    public void Update(Book book) => dbContext.Update(book);
}
