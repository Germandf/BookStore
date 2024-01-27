using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookCategories.CreateBookCategory;

public record CreateBookCategoryRequest(
    string Name,
    string Description)
    : IRequest<Result<BookCategory>>;
