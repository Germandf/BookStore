using FluentValidation;

namespace BookStore.Api.Features.Readlists.CreateReadlist;

public class CreateReadlistValidator : AbstractValidator<CreateReadlistRequest>
{
    public CreateReadlistValidator()
    {
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Description).NotEmpty();

        RuleFor(x => x.UserId).NotEmpty();
    }
}
