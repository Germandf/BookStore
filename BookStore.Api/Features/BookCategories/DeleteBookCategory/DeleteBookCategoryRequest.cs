using MediatR;
using FluentResults;

namespace BookStore.Api.Features.BookCategories.DeleteBookCategory;

public record DeleteBookCategoryRequest(Guid Id) : IRequest<Result<Success>>;
