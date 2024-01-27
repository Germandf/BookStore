using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookLists.GetBookLists;

public class GetBookListsHandler(IRepository<BookList> bookListRepository) : IRequestHandler<GetBookListsRequest, Result<List<BookList>>>
{
    public async Task<Result<List<BookList>>> Handle(GetBookListsRequest request, CancellationToken cancellationToken)
    {
        var bookLists = await bookListRepository.GetAll();

        return bookLists;
    }
}
