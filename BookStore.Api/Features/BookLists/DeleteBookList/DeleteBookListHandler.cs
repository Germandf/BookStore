using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookLists.DeleteBookList;

public class DeleteBookListHandler(
    IRepository<BookList> bookListRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteBookListRequest, Result<Success>>
{
    public async Task<Result<Success>> Handle(DeleteBookListRequest request, CancellationToken cancellationToken)
    {
        var bookList = await bookListRepository.GetById(request.Id);

        if (bookList is null)
            return Result.Fail($"BookList {request.Id} not found.");

        bookListRepository.Remove(bookList);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
