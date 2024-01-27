using BookStore.Api.Persistence;
using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookCategories.CreateBookCategory;

public class CreateBookCategoryHandler(
    IRepository<BookCategory> bookCategoryRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateBookCategoryRequest, Result<BookCategory>>
{
    public async Task<Result<BookCategory>> Handle(CreateBookCategoryRequest request, CancellationToken cancellationToken)
    {
        var bookCategory = new BookCategory
        {
            Name = request.Name,
            Description = request.Description
        };

        bookCategoryRepository.Add(bookCategory);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return bookCategory;
    }
}
