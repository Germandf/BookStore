using BookStore.Api.Common;
using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.UpdateBookPrice;

public class UpdateBookPriceHandler(
    IRepository<Book> bookRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBookPriceRequest, Result<Success>>
{
    public async Task<Result<Success>> Handle(UpdateBookPriceRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(request.Id);

        if (book is null)
            return Result.Fail(Errors.EntityNotFound<Book>(request.Id));

        if (request.Price < book.Price)
            return Result.Fail(Errors.NewPriceBelowCurrent(request.Price, book.Price));

        book.Price = request.Price;

        bookRepository.Update(book);

        await unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}
