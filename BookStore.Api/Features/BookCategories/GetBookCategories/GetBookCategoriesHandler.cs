using MediatR;
using FluentResults;
using BookStore.Api.Persistence;

namespace BookStore.Api.Features.BookCategories.GetBookCategories;

public class GetBookCategoriesHandler(IRepository<BookCategory> bookCategoryRepository) : IRequestHandler<GetBookCategoriesRequest, Result<List<BookCategory>>>
{
    public async Task<Result<List<BookCategory>>> Handle(GetBookCategoriesRequest request, CancellationToken cancellationToken)
    {
        var bookCategories = await bookCategoryRepository.GetAll();

        return bookCategories;
    }
}
