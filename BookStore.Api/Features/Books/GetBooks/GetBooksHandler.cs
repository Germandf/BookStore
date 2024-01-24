using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.GetBooks;

public class GetBooksHandler(
    IRepository<Book> bookRepository)
    : IRequestHandler<GetBooksRequest, Result<List<Book>>>
{
    public async Task<Result<List<Book>>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
    {
        var books = await bookRepository.GetAll(cancellationToken);

        return books;
    }
}
