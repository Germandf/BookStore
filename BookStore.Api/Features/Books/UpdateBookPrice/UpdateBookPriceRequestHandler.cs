using FluentResults;
using MediatR;
using BookStore.Api.Persistence;

namespace BookStore.Api.Features.Books.UpdateBookPrice;

public class UpdateBookPriceRequestHandler(
    IBookRepository bookRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBookPriceRequest, Result<Success>>
{
    public async Task<Result<Success>> Handle(UpdateBookPriceRequest request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetById(request.Id);

        if (book is null)
            return Result.Fail("Book not found");

        if (book.Price > request.Price)
            return Result.Fail("New price cannot be lower than the current price");

        book.Price = request.Price;

        bookRepository.Update(book);

        await unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}
