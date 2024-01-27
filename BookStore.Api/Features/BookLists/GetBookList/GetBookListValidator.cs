using FluentValidation;

namespace BookListStore.Api.Features.BookLists.GetBookList;

public class GetBookListValidator : AbstractValidator<GetBookListRequest>
{
    public GetBookListValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}
