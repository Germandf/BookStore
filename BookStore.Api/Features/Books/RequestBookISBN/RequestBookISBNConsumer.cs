using BookStore.Api.Common;
using BookStore.Api.Persistence;
using BookStore.Events.Books;
using MassTransit;

namespace BookStore.Api.Features.Books.RequestBookISBN;

public class RequestBookISBNConsumer(
    IISBNService iSBNService,
    IRepository<Book> bookRepository,
    IUnitOfWork unitOfWork,
    ILogger<RequestBookISBNConsumer> logger)
    : IConsumer<BookCreatedEvent>
{
    public async Task Consume(ConsumeContext<BookCreatedEvent> context)
    {
        var bookCreatedEvent = context.Message;

        var book = await bookRepository.GetById(bookCreatedEvent.Id);

        if (book is null)
            throw new InvalidOperationException(Errors.EntityNotFound<Book>(bookCreatedEvent.Id));

        book.ISBN = await iSBNService.GetISBN(bookCreatedEvent.Title, bookCreatedEvent.Author);

        bookRepository.Update(book);

        await unitOfWork.SaveChangesAsync();

        logger.LogInformation("ISBN for book {BookId} is {ISBN}", book.Id, book.ISBN);
    }
}
