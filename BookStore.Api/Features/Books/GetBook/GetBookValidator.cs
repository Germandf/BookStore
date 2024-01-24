using FluentValidation;

namespace BookStore.Api.Features.Books.GetBook;

public class GetBookValidator : AbstractValidator<GetBookRequest>
{
    public GetBookValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}
