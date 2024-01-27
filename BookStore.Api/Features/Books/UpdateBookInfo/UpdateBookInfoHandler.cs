using BookStore.Api.Common;
using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.UpdateBookInfo;

public class UpdateBookInfoHandler(
    IRepository<Book> bookRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBookInfoRequest, Result<Success>>
{
    public async Task<Result<Success>> Handle(UpdateBookInfoRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(request.Id, cancellationToken);

        if (book is null)
            return Result.Fail(Errors.EntityNotFound<Book>(request.Id));

        if (book.ISBN is not null)
            return Result.Fail(Errors.BookUpdateWithISBN(book.ISBN));

        book.Title = request.Title;
        book.Author = request.Author;

        bookRepository.Update(book);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
