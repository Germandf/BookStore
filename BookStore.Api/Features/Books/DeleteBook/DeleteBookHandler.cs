using MediatR;
using FluentResults;
using BookStore.Api.Persistence;

namespace BookStore.Api.Features.Books.DeleteBook;

public class DeleteBookHandler(
    IBookRepository bookRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteBookRequest, Result<Success>>
{
    public async Task<Result<Success>> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.Get(request.Id);

        if (book is null)
            return Result.Fail($"Book with id {request.Id} was not found");

        bookRepository.Remove(book);

        await unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}
