using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookCategories.DeleteBookCategory;

public record DeleteBookCategoryRequest(Guid Id) : IRequest<Result<Success>>;
