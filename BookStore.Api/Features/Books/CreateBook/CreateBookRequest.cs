using FluentResults;
using MediatR;

namespace BookStore.Api.Features.Books.CreateBook;

public record CreateBookRequest(
    string Title,
    string Author,
    decimal Price)
    : IRequest<Result<Book>>;
