using BookStore.Api.Common;
using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookCategories.DeleteBookCategory;

public class DeleteBookCategoryHandler(
    IRepository<BookCategory> bookCategoryRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteBookCategoryRequest, Result<Success>>
{
    public async Task<Result<Success>> Handle(DeleteBookCategoryRequest request, CancellationToken cancellationToken)
    {
        var bookCategory = await bookCategoryRepository.GetById(request.Id);

        if (bookCategory is null)
            return Result.Fail(Errors.EntityNotFound<BookCategory>(request.Id));

        bookCategoryRepository.Remove(bookCategory);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
