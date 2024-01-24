using MediatR;
using FluentResults;

namespace BookStore.Api.Features.Books.GetBook;

public record GetBookRequest(Guid Id) : IRequest<Result<Book>>;
