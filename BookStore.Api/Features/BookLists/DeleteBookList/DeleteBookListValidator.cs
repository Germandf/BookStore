using FluentValidation;

namespace BookStore.Api.Features.BookLists.DeleteBookList;

public class DeleteBookListValidator : AbstractValidator<DeleteBookListRequest>
{
    public DeleteBookListValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
