using FluentValidation;

namespace ReadlistStore.Api.Features.Readlists.GetReadlist;

public class GetReadlistValidator : AbstractValidator<GetReadlistRequest>
{
    public GetReadlistValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}
