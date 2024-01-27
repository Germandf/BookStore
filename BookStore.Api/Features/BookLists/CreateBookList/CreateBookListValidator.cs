using FluentValidation;

namespace BookStore.Api.Features.BookLists.CreateBookList;

public class CreateBookListValidator : AbstractValidator<CreateBookListRequest>
{
    public CreateBookListValidator()
    {
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Description).NotEmpty();

        RuleFor(x => x.UserId).NotEmpty();
    }
}
