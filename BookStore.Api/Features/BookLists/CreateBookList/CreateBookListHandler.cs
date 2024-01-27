using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookLists.CreateBookList;

public class CreateBookListHandler(
    IRepository<BookList> bookListRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateBookListRequest, Result<BookList>>
{
    public async Task<Result<BookList>> Handle(CreateBookListRequest request, CancellationToken cancellationToken)
    {
        var bookList = new BookList
        {
            Name = request.Name,
            Description = request.Description,
            UserId = request.UserId
        };

        bookListRepository.Add(bookList);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return bookList;
    }
}
