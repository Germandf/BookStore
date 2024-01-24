using FluentValidation;

namespace BookStore.Api.Features.BookCategories.CreateBookCategory;

public class CreateBookCategoryValidator : AbstractValidator<CreateBookCategoryRequest>
{
    public CreateBookCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Description).NotEmpty();
    }
}
