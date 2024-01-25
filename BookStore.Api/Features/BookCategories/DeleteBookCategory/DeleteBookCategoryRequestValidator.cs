using FluentValidation;

namespace BookStore.Api.Features.BookCategories.DeleteBookCategory;

public class DeleteBookCategoryRequestValidator : AbstractValidator<DeleteBookCategoryRequest>
{
    public DeleteBookCategoryRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
