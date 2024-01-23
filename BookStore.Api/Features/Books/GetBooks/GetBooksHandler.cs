using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.GetBooks;

public class GetBooksHandler(IBookRepository bookRepository) : IRequestHandler<GetBooksRequest, Result<List<Book>>>
{
    public async Task<Result<List<Book>>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
    {
        var books = await bookRepository.GetBooks(cancellationToken);

        return books;
    }
}
