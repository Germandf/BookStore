using FluentValidation;

namespace BookStore.Api.Features.BookCategories.UpdateBookCategory;

public class UpdateBookCategoryValidator : AbstractValidator<UpdateBookCategoryRequest>
{
    public UpdateBookCategoryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Description).NotEmpty();
    }
}
