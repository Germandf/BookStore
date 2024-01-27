using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.DeleteBook;

public record DeleteBookRequest(Guid Id) : IRequest<Result<Success>>;
