using MediatR;
using FluentResults;

namespace BookStore.Api.Features.BookCategories.CreateBookCategory;

public record CreateBookCategoryRequest(
    string Name,
    string Description)
    : IRequest<Result<BookCategory>>;
