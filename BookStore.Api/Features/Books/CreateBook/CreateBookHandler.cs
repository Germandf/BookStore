using BookStore.Api.Persistence;
using BookStore.Events.Books;
using FluentResults;
using MassTransit;
using MediatR;

namespace BookStore.Api.Features.Books.CreateBook;

public class CreateBookHandler(
    IRepository<Book> bookRepository,
    IUnitOfWork unitOfWork,
    IPublishEndpoint publishEndpoint)
    : IRequestHandler<CreateBookRequest, Result<Book>>
{
    public async Task<Result<Book>> Handle(CreateBookRequest request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Price = request.Price
        };

        bookRepository.Add(book);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish(new BookCreatedEvent(book.Id, book.Title, book.Author, book.Price), cancellationToken);

        return book;
    }
}
