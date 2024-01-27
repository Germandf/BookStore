using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.GetBook;

public record GetBookRequest(Guid Id) : IRequest<Result<Book>>;
