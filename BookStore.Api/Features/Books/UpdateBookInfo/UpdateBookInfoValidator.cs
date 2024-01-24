using FluentValidation;

namespace BookStore.Api.Features.Books.UpdateBookInfo;

public class UpdateBookInfoValidator : AbstractValidator<UpdateBookInfoRequest>
{
    public UpdateBookInfoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Title).NotEmpty();

        RuleFor(x => x.Author).NotEmpty();
    }
}
