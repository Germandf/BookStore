using FluentValidation;

namespace BookStore.Api.Features.Books.CreateBook;

public class CreateBookValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookValidator()
    {
        RuleFor(request => request.Title).NotEmpty();

        RuleFor(request => request.Author).NotEmpty();

        RuleFor(request => request.Price).GreaterThan(0);
    }
}
