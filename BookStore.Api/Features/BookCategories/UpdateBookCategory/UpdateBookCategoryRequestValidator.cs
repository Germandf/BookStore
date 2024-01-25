using FluentValidation;

namespace BookStore.Api.Features.BookCategories.UpdateBookCategory;

public class UpdateBookCategoryRequestValidator : AbstractValidator<UpdateBookCategoryRequest>
{
    public UpdateBookCategoryRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Description).NotEmpty();
    }
}
