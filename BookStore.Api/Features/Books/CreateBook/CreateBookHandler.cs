using BookStore.Api.Persistence;
using BookStore.Events.Books;
using FluentResults;
using MassTransit;
using MediatR;

namespace BookStore.Api.Features.Books.CreateBook;

public class CreateBookHandler(
    IBookRepository bookRepository,
    IUnitOfWork unitOfWork,
    IPublishEndpoint publishEndpoint)
    : IRequestHandler<CreateBookRequest, Result<CreateBookResponse>>
{
    public async Task<Result<CreateBookResponse>> Handle(CreateBookRequest request, CancellationToken cancellationToken)
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

        return new CreateBookResponse(book.Id);
    }
}
