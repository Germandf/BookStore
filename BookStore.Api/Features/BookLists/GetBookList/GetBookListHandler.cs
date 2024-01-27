using BookStore.Api.Features.BookLists;
using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookListStore.Api.Features.BookLists.GetBookList;

public class GetBookListHandler(
    IRepository<BookList> bookRepository)
    : IRequestHandler<GetBookListRequest, Result<BookList>>
{
    public async Task<Result<BookList>> Handle(GetBookListRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(request.Id);

        if (book is null)
            return Result.Fail($"BookList with id {request.Id} was not found");

        return Result.Ok(book);
    }
}
