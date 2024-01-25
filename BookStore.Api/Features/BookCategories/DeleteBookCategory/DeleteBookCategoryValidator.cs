using FluentValidation;

namespace BookStore.Api.Features.BookCategories.DeleteBookCategory;

public class DeleteBookCategoryValidator : AbstractValidator<DeleteBookCategoryRequest>
{
    public DeleteBookCategoryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
