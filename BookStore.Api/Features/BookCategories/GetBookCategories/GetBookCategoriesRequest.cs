using FluentResults;
using MediatR;

namespace BookStore.Api.Features.BookCategories.GetBookCategories;

public record GetBookCategoriesRequest : IRequest<Result<List<BookCategory>>>;
