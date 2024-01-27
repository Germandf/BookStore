using FluentValidation;

namespace BookStore.Api.Features.Readlists.DeleteReadlist;

public class DeleteReadlistValidator : AbstractValidator<DeleteReadlistRequest>
{
    public DeleteReadlistValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
