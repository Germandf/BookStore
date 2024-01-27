using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookCategories.UpdateBookCategory;

public class UpdateBookCategoryHandler(
    IRepository<BookCategory> bookCategoryRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateBookCategoryRequest, Result<BookCategory>>
{
    public async Task<Result<BookCategory>> Handle(UpdateBookCategoryRequest request, CancellationToken cancellationToken)
    {
        var bookCategory = await bookCategoryRepository.GetById(request.Id);

        if (bookCategory is null)
            return Result.Fail($"BookCategory {request.Id} not found.");

        bookCategory.Name = request.Name;
        bookCategory.Description = request.Description;

        bookCategoryRepository.Update(bookCategory);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return bookCategory;
    }
}
