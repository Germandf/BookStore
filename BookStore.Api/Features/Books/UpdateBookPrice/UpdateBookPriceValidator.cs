using FluentValidation;

namespace BookStore.Api.Features.Books.UpdateBookPrice;

public class UpdateBookPriceValidator : AbstractValidator<UpdateBookPriceRequest>
{
    public UpdateBookPriceValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Price).GreaterThan(0);
    }
}
