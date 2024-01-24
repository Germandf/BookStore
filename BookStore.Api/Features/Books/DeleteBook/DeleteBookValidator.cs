using FluentValidation;

namespace BookStore.Api.Features.Books.DeleteBook;

public class DeleteBookValidator : AbstractValidator<DeleteBookRequest>
{
    public DeleteBookValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
