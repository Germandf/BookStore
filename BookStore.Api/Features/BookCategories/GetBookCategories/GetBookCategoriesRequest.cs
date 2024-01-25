using MediatR;
using FluentResults;

namespace BookStore.Api.Features.BookCategories.GetBookCategories;

public record GetBookCategoriesRequest : IRequest<Result<List<BookCategory>>>;
