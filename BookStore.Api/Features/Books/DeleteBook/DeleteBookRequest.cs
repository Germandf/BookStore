using MediatR;
using FluentResults;

namespace BookStore.Api.Features.Books.DeleteBook;

public record DeleteBookRequest(Guid Id) : IRequest<Result<Success>>;
