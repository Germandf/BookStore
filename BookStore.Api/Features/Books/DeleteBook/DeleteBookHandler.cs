using BookStore.Api.Common;
using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.DeleteBook;

public class DeleteBookHandler(
    IRepository<Book> bookRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteBookRequest, Result<Success>>
{
    public async Task<Result<Success>> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(request.Id);

        if (book is null)
            return Result.Fail(Errors.EntityNotFound<Book>(request.Id));

        bookRepository.Remove(book);

        await unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}
