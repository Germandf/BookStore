using BookStore.Api.Features.BookCategories;
using BookStore.Api.Features.Readlists;
using BookStore.Api.Features.Books;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Persistence;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<Readlist> Readlists { get; set; }
    public DbSet<ReadlistItem> ReadlistItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Categories)
            .WithMany(c => c.Books);
    }
}
