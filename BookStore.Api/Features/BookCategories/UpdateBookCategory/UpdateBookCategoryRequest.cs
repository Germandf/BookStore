using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookCategories.UpdateBookCategory;

public record UpdateBookCategoryRequest(
    Guid Id,
    string Name,
    string Description)
    : IRequest<Result<BookCategory>>;
