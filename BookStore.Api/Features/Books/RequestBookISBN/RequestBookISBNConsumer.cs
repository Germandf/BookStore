using BookStore.Api.Persistence;
using BookStore.Events.Books;
using MassTransit;

namespace BookStore.Api.Features.Books.RequestBookISBN;

public class RequestBookISBNConsumer(
    IISBNService iSBNService,
    IBookRepository bookRepository,
    IUnitOfWork unitOfWork,
    ILogger<RequestBookISBNConsumer> logger)
    : IConsumer<BookCreatedEvent>
{
    public async Task Consume(ConsumeContext<BookCreatedEvent> context)
    {
        var bookCreatedEvent = context.Message;

        var book = await bookRepository.Get(bookCreatedEvent.Id);

        if (book is null)
            throw new InvalidOperationException($"Book with id {bookCreatedEvent.Id} was not found");

        book.ISBN = await iSBNService.GetISBN(bookCreatedEvent.Title, bookCreatedEvent.Author);

        bookRepository.Update(book);

        await unitOfWork.SaveChangesAsync();

        logger.LogInformation("ISBN for book {BookId} is {ISBN}", book.Id, book.ISBN);
    }
}
